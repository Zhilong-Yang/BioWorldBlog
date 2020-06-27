using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.CustomPage.Queries.GetCustomePageById
{
    public class GetCustomPageByIdQuery : IRequest<CustomPageDto>
    {
        public Guid PageId { get; set; }
    }

    public class GetCustomPageByIdQueryHandler : IRequestHandler<GetCustomPageByIdQuery, CustomPageDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomPageByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomPageDto> Handle(GetCustomPageByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CustomPage.FindAsync(request.PageId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomPage), request.PageId);
            }

            return new CustomPageDto()
            {
                Id = entity.Id,
                Title = entity.Title.Trim(),
                CreateOnUtc = entity.CreateOnUtc,
                CssContent = entity.CssContent,
                RawHtmlContent = entity.HtmlContent,
                HideSidebar = entity.HideSidebar,
                Slug = entity.Slug.Trim().ToLower(),
                MetaDescription = entity.MetaDescription?.Trim(),
                UpdatedOnUtc = entity.UpdatedOnUtc,
                IsPublished = entity.IsPublished
            };
        }
    }
}