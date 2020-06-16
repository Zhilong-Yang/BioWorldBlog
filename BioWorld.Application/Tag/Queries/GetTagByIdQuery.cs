using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries
{
    public class GetTagByIdQuery : IRequest<TagDto>
    {
        public int Id { get; set; }
    }

    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto>
    {
        private readonly IApplicationDbContext _context;

        public GetTagByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
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