using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BioWorld.Application.Post.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostDto>
    {
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

        public CreatePostCommand()
        {
            Tags = new string[] { };
            CategoryIds = new Guid[] { };
        }
    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostDto>
    {
        private readonly IApplicationDbContext _context;

        private readonly AppSettings AppSettings;

        public CreatePostCommandHandler(IApplicationDbContext context,
            IOptions<AppSettings> settings = null)
        {
            if (null != settings) AppSettings = settings.Value;
            _context = context;
        }

        public async Task<CreatePostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var postModel = new PostEntity
            {
                CommentEnabled = request.EnableComment,
                Id = Guid.NewGuid(),
                PostContent = request.EditorContent,
                ContentAbstract = Utils.GetPostAbstract(
                    request.EditorContent,
                    AppSettings.PostAbstractWords,
                    AppSettings.Editor == EditorChoice.Markdown),
                CreateOnUtc = DateTime.UtcNow,
                Slug = request.Slug.ToLower().Trim(),
                Title = request.Title.Trim(),
                PostPublish = new PostPublishEntity
                {
                    IsDeleted = false,
                    IsPublished = request.IsPublished,
                    PubDateUtc = request.IsPublished ? DateTime.UtcNow : (DateTime?) null,
                    ExposedToSiteMap = request.ExposedToSiteMap,
                    IsFeedIncluded = request.IsFeedIncluded,
                    Revision = 0,
                    ContentLanguageCode = request.ContentLanguageCode,
                    PublisherIp = request.RequestIp
                },
                PostExtension = new PostExtensionEntity
                {
                    Hits = 0,
                    Likes = 0
                }
            };

            // check if exist same slug under the same day
            // linq to sql fix:
            // cannot write "p.PostPublish.PubDateUtc.GetValueOrDefault().Date == DateTime.UtcNow.Date"
            // it will not blow up, but can result in select ENTIRE posts and evaluated in memory!!!
            // - The LINQ expression 'where (Convert([p.PostPublish]?.PubDateUtc?.GetValueOrDefault(), DateTime).Date == DateTime.UtcNow.Date)' could not be translated and will be evaluated locally
            if (_context.Post.Any(p =>
                p.Slug == postModel.Slug &&
                p.PostPublish.PubDateUtc != null &&
                p.PostPublish.PubDateUtc.Value.Year == DateTime.UtcNow.Date.Year &&
                p.PostPublish.PubDateUtc.Value.Month == DateTime.UtcNow.Date.Month &&
                p.PostPublish.PubDateUtc.Value.Day == DateTime.UtcNow.Date.Day))
            {
                var uid = Guid.NewGuid();
                postModel.Slug += $"-{uid.ToString().ToLower().Substring(0, 8)}";
            }

            // add categories
            if (null != request.CategoryIds && request.CategoryIds.Length > 0)
            {
                foreach (var cid in request.CategoryIds)
                {
                    if (_context.Category.Any(c => c.Id == cid))
                    {
                        postModel.PostCategory.Add(new PostCategoryEntity
                        {
                            CategoryId = cid,
                            PostId = postModel.Id
                        });
                    }
                }
            }

            // add tags
            if (null != request.Tags && request.Tags.Length > 0)
            {
                foreach (var item in request.Tags)
                {
                    if (!Utils.ValidateTagName(item))
                    {
                        continue;
                    }

                    var tag = await _context.Tag.FirstOrDefaultAsync(q => q.DisplayName == item,
                        cancellationToken: cancellationToken);
                    if (null == tag)
                    {
                        var newTag = new TagEntity
                        {
                            DisplayName = item,
                            NormalizedName = Utils.NormalizeTagName(item)
                        };

                        await _context.Tag.AddAsync(newTag, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    postModel.PostTag.Add(new PostTagEntity
                    {
                        TagId = tag.Id,
                        PostId = postModel.Id
                    });
                }

                await _context.Post.AddAsync(postModel, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return new CreatePostDto()
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Slug = postModel.Slug,
                EditorContent = postModel.PostContent,
                EnableComment = postModel.CommentEnabled,
                IsPublished = postModel.PostPublish.IsPublished,
                ExposedToSiteMap = postModel.PostPublish.ExposedToSiteMap,
                IsFeedIncluded = postModel.PostPublish.IsFeedIncluded,
                ContentLanguageCode =postModel.PostPublish.ContentLanguageCode,
                RequestIp = postModel.PostPublish.PublisherIp,
                PublishDate = postModel.PostPublish.PubDateUtc,
                Tags = request.Tags,
                CategoryIds = request.CategoryIds
            };
        }
    }
}

