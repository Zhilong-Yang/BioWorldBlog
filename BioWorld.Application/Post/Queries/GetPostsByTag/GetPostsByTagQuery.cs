using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetPostsByTag
{
    public class GetPostsByTagQuery : IRequest<IReadOnlyList<GetPostsByTagDto>>
    {
        public int TagId { get; set; }
    }

    public class GetPostsByTagQueryHandler : IRequestHandler<GetPostsByTagQuery, IReadOnlyList<GetPostsByTagDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPostsByTagQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<GetPostsByTagDto>> Handle(GetPostsByTagQuery request,
            CancellationToken cancellationToken)
        {
            if (request.TagId == 0)
            {
                throw new BadRequestException(
                    $"{nameof(request.TagId)} can not be less than 1, current value: {request.TagId}.");
            }

            var posts = await _context.PostTag
                .Where(pt => pt.TagId == request.TagId
                             && !pt.Post.PostPublish.IsDeleted
                             && pt.Post.PostPublish.IsPublished)
                .AsNoTracking()
                .Select(p => new GetPostsByTagDto
                {
                    Title = p.Post.Title,
                    Slug = p.Post.Slug,
                    ContentAbstract = p.Post.ContentAbstract,
                    PubDateUtc = p.Post.PostPublish.PubDateUtc.GetValueOrDefault()
                })
                .ToListAsync(cancellationToken: cancellationToken);
            return posts;
        }
    }
}