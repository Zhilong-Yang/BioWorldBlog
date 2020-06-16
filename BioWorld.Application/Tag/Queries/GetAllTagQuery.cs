using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries
{
    public class GetAllTagQuery : IRequest<IReadOnlyList<TagDto>>
    {
    }

    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, IReadOnlyList<TagDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTagQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TagDto>> Handle(GetAllTagQuery request,
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

            return tags;
        }
    }
}