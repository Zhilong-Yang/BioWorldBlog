using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Menu.Commands.UpdateMenu
{
    public class UpdateMenuCommand: IRequest<MenuDto>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsOpenInNewTab { get; set; }
    }

    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, MenuDto>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuDto> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menu.FindAsync(request.Id);

            if (menu == null)
            {
                throw new NotFoundException(nameof(MenuEntity), request.Id);
            }

            var sUrl = Utils.SterilizeMenuLink(request.Url.Trim());

            menu.Title = request.Title.Trim();
            menu.Url = sUrl;
            menu.DisplayOrder = request.DisplayOrder;
            menu.Icon = request.Icon;
            menu.IsOpenInNewTab = request.IsOpenInNewTab;
            await _context.SaveChangesAsync(cancellationToken);
            
            return new MenuDto()
            {
                Id = menu.Id,
                Title = menu.Title.Trim(),
                DisplayOrder = menu.DisplayOrder,
                Icon = menu.Icon.Trim(),
                Url = menu.Url.Trim(),
                IsOpenInNewTab = menu.IsOpenInNewTab
            };
        }
    }
}
