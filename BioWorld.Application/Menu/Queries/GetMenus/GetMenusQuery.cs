using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Menu.Queries.GetMenus
{
    public class GetMenusQuery : IRequest<MenuJsonDto>
    {
        public class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, MenuJsonDto>
        {
            private readonly IApplicationDbContext _context;

            public GetMenusQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<MenuJsonDto> Handle(GetMenusQuery request, CancellationToken cancellationToken)
            {
                var menus = await _context.Menu
                    .Select(p => new MenuDto()
                    {
                        Id = p.Id,
                        Title = p.Title.Trim(),
                        DisplayOrder = p.DisplayOrder,
                        Icon = p.Icon.Trim(),
                        Url = p.Url.Trim(),
                        IsOpenInNewTab = p.IsOpenInNewTab
                    })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return new MenuJsonDto(menus);
            }
        }
    }
}