using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries
{
    public class GetAllTagsNameQuery : IRequest<TagsNameListDto>
    {
    }

    public class GetAllTagsNameQueryHandler : IRequestHandler<GetAllTagsNameQuery, TagsNameListDto>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTagsNameQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TagsNameListDto> Handle(GetAllTagsNameQuery request,
            CancellationToken cancellationToken)
        {
            var names = await _context.Tag
                .AsNoTracking()
                .Select(t => t.DisplayName)
                .ToListAsync(cancellationToken);

            var vm = new TagsNameListDto
            {
                TagsName = names
            };

            return vm;
        }
    }
}