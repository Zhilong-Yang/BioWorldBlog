using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Category;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Tag.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetPostListItem
{
    public class GetPostListItemQuery : IRequest<PostDto>
    {
        public Guid Id { get; set; }
    }

    public class GetPostListItemQueryHandler : IRequestHandler<GetPostListItemQuery, PostDto>
    {
        private readonly IApplicationDbContext _context;

        public GetPostListItemQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostDto> Handle(GetPostListItemQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Post
                .Where(p => p.Id == request.Id)
                .Include(p => p.PostPublish)
                .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                .AsNoTracking()
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    RawPostContent = p.PostContent,
                    ContentAbstract = p.ContentAbstract,
                    CommentEnabled = p.CommentEnabled,
                    CreateOnUtc = p.CreateOnUtc,
                    PubDateUtc = p.PostPublish.PubDateUtc,
                    IsPublished = p.PostPublish.IsPublished,
                    ExposedToSiteMap = p.PostPublish.ExposedToSiteMap,
                    FeedIncluded = p.PostPublish.IsFeedIncluded,
                    ContentLanguageCode = p.PostPublish.ContentLanguageCode,
                    Tags = p.PostTag.Select(pt => new TagDto()
                    {
                        Id = pt.TagId,
                        NormalizedName = pt.Tag.NormalizedName,
                        TagName = pt.Tag.DisplayName
                    }).ToList(),
                    Categories = p.PostCategory.Select(pc => new CategoryDto()
                    {
                        Id = pc.CategoryId,
                        DisplayName = pc.Category.DisplayName,
                        RouteName = pc.Category.RouteName,
                        Note = pc.Category.Note
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return post;
        }
    }
}