using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Menu.Commands.CreateMenu
{
    public class CreateMenuCommand : IRequest<MenuDto>
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsOpenInNewTab { get; set; }
    }

    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, MenuDto>
    {
        private readonly IApplicationDbContext _context;

        public CreateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuDto> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var uid = Guid.NewGuid();
            var menu = new MenuEntity
            {
                Id = uid,
                Title = request.Title.Trim(),
                DisplayOrder = request.DisplayOrder,
                Icon = request.Icon,
                Url = request.Url,
                IsOpenInNewTab = request.IsOpenInNewTab
            };

            await _context.Menu.AddAsync(menu, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new MenuDto()
            {
                Id = menu.Id,
                Title = menu.Title,
                DisplayOrder = menu.DisplayOrder,
                Icon = menu.Icon,
                Url = menu.Url,
                IsOpenInNewTab = menu.IsOpenInNewTab
            };
        }
    }
}