using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Post.Queries.GetAllPostListItem;
using BioWorld.Application.Tag.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetArchived
{
    public class GetArchivedQuery : IRequest<PostListItemJsonDto>
    {
        public int Year { get; set; }

        public int Month { get; set; } = 0;
    }

    public class GetArchivedQueryHandler : IRequestHandler<GetArchivedQuery, PostListItemJsonDto>
    {
        private readonly IApplicationDbContext _context;

        public GetArchivedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostListItemJsonDto> Handle(GetArchivedQuery request,
            CancellationToken cancellationToken)
        {
            if (request.Year < DateTime.MinValue.Year || request.Year > DateTime.MaxValue.Year)
            {
                throw new BadRequestException(
                    $"{nameof(request.Year)} is out of range, current value: {request.Year}.");
            }

            if (request.Month > 12 || request.Month < 0)
            {
                throw new BadRequestException(
                    $"{nameof(request.Month)} is out of range, current value: {request.Month}.");
            }

            var list = await _context.Post
                .Where(p => (p.PostPublish.PubDateUtc.Value.Year == request.Year) &&
                            (p.PostPublish.IsPublished && !p.PostPublish.IsDeleted) &&
                            (request.Month == 0 || p.PostPublish.PubDateUtc.Value.Month == request.Month))
                .Include(p => p.PostPublish)
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
                .ToListAsync(cancellationToken);

            return new PostListItemJsonDto(list);
        }
    }
}