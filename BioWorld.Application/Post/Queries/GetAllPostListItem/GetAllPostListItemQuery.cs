using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Tag.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetAllPostListItem
{
    public class GetAllPostListItemQuery : IRequest<IReadOnlyList<PostListItemDto>>
    {
        public Paging Param { get; set; }
    }

    public class GetAllPostListItemQueryHandler : IRequestHandler<GetAllPostListItemQuery, IReadOnlyList<PostListItemDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPostListItemQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<PostListItemDto>> Handle(GetAllPostListItemQuery request,
            CancellationToken cancellationToken)
        {
            var pageSize = request.Param.PageSize;
            var pageIndex = request.Param.PageNumber;

            if (pageSize < 1)
            {
                throw new BadRequestException(
                    $"{nameof(pageSize)} can not be less than 1, current value: {pageSize}.");
            }

            if (pageIndex < 1)
            {
                throw new BadRequestException(
                    $"{nameof(pageIndex)} can not be less than 1, current value: {pageIndex}.");
            }

            // Expression<Func<PostEntity, bool>> criteria = (p => !p.PostPublish.IsDeleted && p.PostPublish.IsPublished);//                                                    

            var posts = await _context.Post
                .Where(p => !p.PostPublish.IsDeleted && p.PostPublish.IsPublished)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(p => p.PostPublish.PubDateUtc)
                .Select(p => new PostListItemDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    ContentAbstract = p.ContentAbstract,
                    PubDateUtc = p.PostPublish.PubDateUtc.GetValueOrDefault(),
                    Tags = p.PostTag.Select(pt => new TagDto
                    {
                        Id = pt.TagId,
                        NormalizedName = pt.Tag.NormalizedName,
                        TagName = pt.Tag.DisplayName,
                    }).ToList()
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
            return posts;
        }
    }
}