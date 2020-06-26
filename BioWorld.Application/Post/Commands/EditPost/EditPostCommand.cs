using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BioWorld.Application.Post.Commands.EditPost
{
    public class EditPostCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string EditorContent { get; set; }
        public bool EnableComment { get; set; }
        public bool IsPublished { get; set; }
        public bool ExposedToSiteMap { get; set; }
        public bool IsFeedIncluded { get; set; }
        public string ContentLanguageCode { get; set; }

        public string[] Tags { get; set; }
        public Guid[] CategoryIds { get; set; }

        public string RequestIp { get; set; }

        public DateTime? PublishDate { get; set; }

        public EditPostCommand()
        {
            Tags = new string[] { };
            CategoryIds = new Guid[] { };
        }
    }

    public class EditPostCommandHandler : IRequestHandler<EditPostCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly AppSettings _appSettings;

        private readonly IDateTime _dateTimeResolver;

        public EditPostCommandHandler(IApplicationDbContext context,
            IDateTime dateTimeResolver,
            IOptions<AppSettings> settings = null)
        {
            if (null != settings) _appSettings = settings.Value;
            _dateTimeResolver = dateTimeResolver;
            _context = context;
        }

        public async Task<Unit> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var postModel = await _context.Post
                .Include(p => p.PostPublish)
                .Include(p => p.PostTag)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategory)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

            if (postModel == null)
            {
                throw new NotFoundException(nameof(PostEntity), request.Id);
            }

            postModel.CommentEnabled = request.EnableComment;
            postModel.PostContent = request.EditorContent;
            postModel.ContentAbstract = Utils.GetPostAbstract(
                request.EditorContent,
                _appSettings.PostAbstractWords,
                _appSettings.Editor == EditorChoice.Markdown);


            // Address #221: Do not allow published posts back to draft status
            // postModel.PostPublish.IsPublished = request.IsPublished;
            // Edit draft -> save and publish, ignore false case because #221
            // bool isNewPublish = false;
            if (request.IsPublished && !postModel.PostPublish.IsPublished)
            {
                postModel.PostPublish.IsPublished = true;
                postModel.PostPublish.PublisherIp = request.RequestIp;
                postModel.PostPublish.PubDateUtc = DateTime.UtcNow;

                // isNewPublish = true;
            }

            // #325: Allow changing publish date for published posts
            if (request.PublishDate != null && postModel.PostPublish.PubDateUtc.HasValue)
            {
                var tod = postModel.PostPublish.PubDateUtc.Value.TimeOfDay;
                var adjustedDate = _dateTimeResolver.GetUtcTimeFromUserTZone(request.PublishDate.Value);
                postModel.PostPublish.PubDateUtc = adjustedDate.AddTicks(tod.Ticks);
            }

            postModel.Slug = request.Slug;
            postModel.Title = request.Title;
            postModel.PostPublish.ExposedToSiteMap = request.ExposedToSiteMap;
            postModel.PostPublish.LastModifiedUtc = DateTime.UtcNow;
            postModel.PostPublish.IsFeedIncluded = request.IsFeedIncluded;
            postModel.PostPublish.ContentLanguageCode = request.ContentLanguageCode;

            ++postModel.PostPublish.Revision;

            // 1. Add new tags to tag lib
            foreach (var item in request.Tags.Where(item => !_context.Tag.Any(p => p.DisplayName == item)))
            {
                await _context.Tag.AddAsync(new TagEntity
                {
                    DisplayName = item,
                    NormalizedName = Utils.NormalizeTagName(item)
                }, cancellationToken);
            }

            // 2. update tags
            postModel.PostTag.Clear();
            if (request.Tags.Any())
            {
                foreach (var tagName in request.Tags)
                {
                    if (!Utils.ValidateTagName(tagName))
                    {
                        continue;
                    }

                    var tag = await _context.Tag.FirstOrDefaultAsync(t => t.DisplayName == tagName,
                        cancellationToken: cancellationToken);
                    if (tag != null)
                        postModel.PostTag.Add(new PostTagEntity
                        {
                            PostId = postModel.Id,
                            TagId = tag.Id
                        });
                }
            }

            // 3. update categories
            postModel.PostCategory.Clear();
            if (null != request.CategoryIds && request.CategoryIds.Length > 0)
            {
                foreach (var cid in request.CategoryIds)
                {
                    if (_context.Category.Any(c => c.Id == cid))
                    {
                        postModel.PostCategory.Add(new PostCategoryEntity
                        {
                            PostId = postModel.Id,
                            CategoryId = cid
                        });
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}