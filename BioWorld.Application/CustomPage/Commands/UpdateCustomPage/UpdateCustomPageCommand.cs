using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.CustomPage.Commands.UpdateCustomPage
{
    public class UpdateCustomPageCommand : IRequest<CustomPageDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string HtmlContent { get; set; }
        public string CssContent { get; set; }
        public bool HideSidebar { get; set; }
        public bool IsPublished { get; set; }
    }

    public class UpdateCustomPageCommandHandler : IRequestHandler<UpdateCustomPageCommand, CustomPageDto>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCustomPageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomPageDto> Handle(UpdateCustomPageCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.CustomPage.FindAsync(request.Id);

            if (menu == null)
            {
                throw new NotFoundException(nameof(CustomPage), request.Id);
            }

            menu.Title = request.Title.Trim();
            menu.Slug = request.Slug.ToLower().Trim();
            menu.MetaDescription = request.MetaDescription;
            menu.HtmlContent = request.HtmlContent;
            menu.CssContent = request.CssContent;
            menu.HideSidebar = request.HideSidebar;
            menu.UpdatedOnUtc = DateTime.UtcNow;
            menu.IsPublished = request.IsPublished;

            await _context.SaveChangesAsync(cancellationToken);

            return new CustomPageDto()
            {
                Id = menu.Id,
                Title = menu.Title.Trim(),
                CreateOnUtc = menu.CreateOnUtc,
                CssContent = menu.CssContent,
                RawHtmlContent = menu.HtmlContent,
                HideSidebar = menu.HideSidebar,
                Slug = menu.Slug.Trim().ToLower(),
                MetaDescription = menu.MetaDescription?.Trim(),
                UpdatedOnUtc = menu.UpdatedOnUtc,
                IsPublished = menu.IsPublished
            };
        }
    }
}