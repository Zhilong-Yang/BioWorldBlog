using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetSegment
{
    public class GetSegmentQuery : IRequest<PostSlugSegmentDto>
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public string Slug { get; set; }
    }

    public class GetArchivedQueryHandler : IRequestHandler<GetSegmentQuery, PostSlugSegmentDto>
    {
        private readonly IApplicationDbContext _context;

        public GetArchivedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostSlugSegmentDto> Handle(GetSegmentQuery request, CancellationToken cancellationToken)
        {
            var date = new DateTime(request.Year, request.Month, request.Day);

            var entity = await _context.Post
                .Where(p => p.Slug == request.Slug &&
                            p.PostPublish.IsPublished &&
                            p.PostPublish.PubDateUtc.Value.Date == date &&
                            !p.PostPublish.IsDeleted)
                .Include(p => p.PostPublish)
                .Include(p => p.PostExtension)
                .Include(p => p.Comment)
                .Include(p => p.PostTag)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategory)
                .ThenInclude(pc => pc.Category)
                .AsNoTracking()
                .Select(post => new PostSlugSegmentDto()
                {
                    Title = post.Title,
                    PubDateUtc = post.PostPublish.PubDateUtc.GetValueOrDefault(),
                    LastModifyOnUtc = post.PostPublish.LastModifiedUtc,

                    Categories = post.PostCategory
                        .Select(pc => pc.Category.DisplayName)
                        .ToArray(),

                    Tags = post.PostTag
                        .Select(pt => pt.Tag.DisplayName)
                        .ToArray()
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return entity;
        }
    }
}