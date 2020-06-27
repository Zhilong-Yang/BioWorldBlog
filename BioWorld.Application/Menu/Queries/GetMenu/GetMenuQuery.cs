using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.Menu.Queries.GetMenu
{
    public class GetMenuQuery : IRequest<MenuDto>
    {
        public Guid Id { get; set; }
    }

    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, MenuDto>
    {
        private readonly IApplicationDbContext _context;

        public GetMenuQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuDto> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Menu.FindAsync(request.Id);

            return new MenuDto()
            {
                Id = entity.Id,
                Title = entity.Title.Trim(),
                DisplayOrder = entity.DisplayOrder,
                Icon = entity.Icon.Trim(),
                Url = entity.Url.Trim(),
                IsOpenInNewTab = entity.IsOpenInNewTab
            };
        }
    }
}