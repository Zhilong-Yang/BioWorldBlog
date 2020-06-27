using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.CustomPage.Commands.CreateCustomPage
{
    public class CreateCustomPageCommand : IRequest<CustomPageDto>
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string HtmlContent { get; set; }
        public string CssContent { get; set; }
        public bool HideSidebar { get; set; }
        public bool IsPublished { get; set; }
    }

    public class CreateCustomPageCommandHandler : IRequestHandler<CreateCustomPageCommand, CustomPageDto>
    {
        private readonly IApplicationDbContext _context;

        public CreateCustomPageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomPageDto> Handle(CreateCustomPageCommand request, CancellationToken cancellationToken)
        {
            var uid = Guid.NewGuid();
            var customPage = new CustomPageEntity
            {
                Id = uid,
                Title = request.Title.Trim(),
                Slug = request.Slug.ToLower().Trim(),
                MetaDescription = request.MetaDescription,
                CreateOnUtc = DateTime.UtcNow,
                HtmlContent = request.HtmlContent,
                CssContent = request.CssContent,
                HideSidebar = request.HideSidebar,
                IsPublished = request.IsPublished
            };

            await _context.CustomPage.AddAsync(customPage, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CustomPageDto()
            {
                Id = customPage.Id,
                Title = customPage.Title.Trim(),
                CreateOnUtc = customPage.CreateOnUtc,
                CssContent = customPage.CssContent,
                RawHtmlContent = customPage.HtmlContent,
                HideSidebar = customPage.HideSidebar,
                Slug = customPage.Slug.Trim().ToLower(),
                MetaDescription = customPage.MetaDescription?.Trim(),
                UpdatedOnUtc = customPage.UpdatedOnUtc,
                IsPublished = customPage.IsPublished
            };
        }
    }
}