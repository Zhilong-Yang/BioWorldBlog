using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetInsights
{
    public class GetInsightsQuery : IRequest<GetInsightsJsonDto>
    {
        public PostInsightsType InsightsType { get; set; }
    }

    public class GetInsightsQueryHandler : IRequestHandler<GetInsightsQuery, GetInsightsJsonDto>
    {
        private readonly IApplicationDbContext _context;

        Expression<Func<PostEntity, object>> orderByDescendingExpression { get; set; }

        public GetInsightsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetInsightsJsonDto> Handle(GetInsightsQuery request, CancellationToken cancellationToken)
        {
            switch (request.InsightsType)
            {
                case PostInsightsType.TopRead:
                    orderByDescendingExpression = (p => p.PostExtension.Hits);
                    break;
                case PostInsightsType.TopCommented:
                    orderByDescendingExpression = (p => p.Comment.Count);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(request.InsightsType), request.InsightsType, null);
            }

            var post = await _context.Post.Where(p => !p.PostPublish.IsDeleted &&
                                                      p.PostPublish.IsPublished &&
                                                      p.PostPublish.PubDateUtc >= DateTime.UtcNow.AddYears(-1))
                .OrderByDescending(orderByDescendingExpression)
                .Skip(0)
                .Take(10)
                .Select(o => new GetInsightsDto()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Slug = o.Slug,
                    PubDateUtc = o.PostPublish.PubDateUtc,
                    IsPublished = o.PostPublish.IsPublished,
                    IsDeleted = o.PostPublish.IsDeleted,
                    Revision = o.PostPublish.Revision,
                    CreateOnUtc = o.CreateOnUtc,
                    Hits = o.PostExtension.Hits
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            return new GetInsightsJsonDto(post);
        }
    }
}