using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries.GetTag
{
    public class GetTagQuery : IRequest<TagDto>
    {
        public int Id { get; set; }
    }

    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, TagDto>
    {
        private readonly IApplicationDbContext _context;

        public GetTagQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TagDto> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Tag
                .AsNoTracking()
                .Where(e => e.Id == request.Id)
                .Select(t => new TagDto
                {
                    Id = t.Id,
                    TagName = t.DisplayName,
                    NormalizedName = t.NormalizedName
                })
                .SingleOrDefaultAsync(cancellationToken);

            return vm;
        }
    }
}