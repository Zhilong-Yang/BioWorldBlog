using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.CustomPage.Queries.GetCustomPageBySlug
{
    public class GetCustomPageBySlugQuery : IRequest<CustomPageDto>
    {
        public string Slug { get; set; }
    }

    public class GetCustomPageBySlugQueryHandler : IRequestHandler<GetCustomPageBySlugQuery, CustomPageDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomPageBySlugQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomPageDto> Handle(GetCustomPageBySlugQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Slug))
            {
                throw new BadRequestException(
                    $"{nameof(request.Slug)} can not be empty, current value: {request.Slug}.");
            }

            var loweredRouteName = request.Slug.ToLower();
            var entity = await _context.CustomPage
                .Where(p => p.Slug == loweredRouteName)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

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