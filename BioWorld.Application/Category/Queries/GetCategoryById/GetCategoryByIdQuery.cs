using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryByIdQueryHandler
        : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Category
                .Where(p => p.Id == request.Id)
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