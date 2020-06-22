using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Category;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Post.Queries.GetPostByDate;
using BioWorld.Application.Tag.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetDraftPreview
{
    public class GetDraftPreviewQuery : IRequest<PostSlugDto>
    {
        public Guid PostId { get; set; }
    }

    public class GetDraftPreviewQueryHandler : IRequestHandler<GetDraftPreviewQuery, PostSlugDto>
    {
        private readonly IApplicationDbContext _context;

        public GetDraftPreviewQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostSlugDto> Handle(GetDraftPreviewQuery request, CancellationToken cancellationToken)
        {
            var postSlugModel = await _context.Post
                .Where(p => p.Id == request.PostId)
                .Include(p => p.PostPublish)
                .Include(p => p.PostTag)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategory)
                .ThenInclude(pc => pc.Category)
                .Select(post => new PostSlugDto
                {
                    Title = post.Title,
                    Abstract = post.ContentAbstract,
                    PubDateUtc = DateTime.UtcNow,
                    Categories = post.PostCategory.Select(pc => pc.Category).Select(p => new CategoryDto()
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        RouteName = p.RouteName
                    }).ToList(),

                    Content = post.PostContent,

                    Tags = post.PostTag.Select(pt => pt.Tag)
                        .Select(p => new TagDto()
                        {
                            Id = p.Id,
                            NormalizedName = p.NormalizedName,
                            TagName = p.DisplayName
                        }).ToList(),
                    PostId = post.Id,
                    IsExposedToSiteMap = post.PostPublish.ExposedToSiteMap,
                    LastModifyOnUtc = post.PostPublish.LastModifiedUtc
                })
                .FirstOrDefaultAsync(cancellationToken);

            return postSlugModel;
        }
    }
}