using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Category.Queries.GetCategoryByName
{
    public class GetCategoryByNameQuery : IRequest<CategoryDto>
    {
        public string CategoryName;
    }

    public class GetCategoryByNameQueryHandler
        : IRequestHandler<GetCategoryByNameQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryByNameQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryByNameQuery request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Category
                .Where(p => p.RouteName == request.CategoryName)
                .Select(cat => new CategoryDto()
                {
                    Id = cat.Id,
                    DisplayName = cat.DisplayName,
                    RouteName = cat.RouteName,
                    Note = cat.Note
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
            return category;
        }
    }
}