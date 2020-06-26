using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetSegments
{
    public class GetSegmentsQuery : IRequest<PostSlugSegmentJsonDto>
    {
        public PostPublishStatus PostPublishStatus { get; set; }
    }

    public class GetSegmentsQueryHandler : IRequestHandler<GetSegmentsQuery, PostSlugSegmentJsonDto>
    {
        private readonly IApplicationDbContext _context;

        public GetSegmentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostSlugSegmentJsonDto> Handle(GetSegmentsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PostEntity, bool>> criteria;

            switch (request.PostPublishStatus)
            {
                case PostPublishStatus.Draft:
                    criteria = (p => !p.PostPublish.IsPublished && !p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.Published:
                    criteria = (p => p.PostPublish.IsPublished && !p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.Deleted:
                    criteria = (p => p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.NotSet:
                    criteria = (p => true);
                    break;
                default:
                    throw new BadRequestException(
                        $"{nameof(request.PostPublishStatus)} invalid, current value: {request.PostPublishStatus}.");
            }

            var entities = await _context.Post
                .AsNoTracking()
                .Select(p => new PostSegmentDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    PubDateUtc = p.PostPublish.PubDateUtc,
                    IsPublished = p.PostPublish.IsPublished,
                    IsDeleted = p.PostPublish.IsDeleted,
                    Revision = p.PostPublish.Revision,
                    CreateOnUtc = p.CreateOnUtc,
                    Hits = p.PostExtension.Hits
                })
                .ToListAsync(cancellationToken: cancellationToken);

            return new PostSlugSegmentJsonDto(entities);
        }
    }
}