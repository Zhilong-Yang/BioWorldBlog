using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries.GetAllTag
{
    public class GetAllTagQuery : IRequest<TagJsonDto>
    {
        public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, TagJsonDto>
        {
            private readonly IApplicationDbContext _context;

            public GetAllTagQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<TagJsonDto> Handle(GetAllTagQuery request,
                CancellationToken cancellationToken)
            {
                var tags = await _context.Tag
                    .AsNoTracking()
                    .Select(t => new TagDto
                    {
                        Id = t.Id,
                        TagName = t.DisplayName,
                        NormalizedName = t.NormalizedName
                    })
                    .ToListAsync(cancellationToken);

                return new TagJsonDto(tags);
            }
        }
    }
}