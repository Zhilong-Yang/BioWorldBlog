using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.CustomPage.Queries.GetCustomPageListSegment
{
    public class GetCustomPageListSegmentQuery : IRequest<CustomPageSegmentJsonDto>
    {
        public class
            GetCustomPageListSegmentQueryHandler : IRequestHandler<GetCustomPageListSegmentQuery,
                CustomPageSegmentJsonDto>
        {
            private readonly IApplicationDbContext _context;

            public GetCustomPageListSegmentQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<CustomPageSegmentJsonDto> Handle(GetCustomPageListSegmentQuery request,
                CancellationToken cancellationToken)
            {
                var list = await _context.CustomPage
                    .Select(page => new CustomPageSegmentDto()
                    {
                        Id = page.Id,
                        CreateOnUtc = page.CreateOnUtc,
                        RouteName = page.Slug,
                        Title = page.Title,
                        IsPublished = page.IsPublished
                    })
                    .ToListAsync(cancellationToken: cancellationToken);

                return new CustomPageSegmentJsonDto(list);
            }
        }
    }
}