using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Category.Queries.GetAllCategoryListItem
{
    public class GetAllCategoryQuery : IRequest<IReadOnlyList<CategoryDto>>
    {
        public class GetAllCategoryQueryHandler
            : IRequestHandler<GetAllCategoryQuery, IReadOnlyList<CategoryDto>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllCategoryQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IReadOnlyList<CategoryDto>> Handle(GetAllCategoryQuery request,
                CancellationToken cancellationToken)
            {
                var categories = await _context.Category
                    .Select(cat => new CategoryDto()
                    {
                        Id = cat.Id,
                        DisplayName = cat.DisplayName,
                        RouteName = cat.RouteName,
                        Note = cat.Note
                    })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return categories;
            }
        }
    }
}