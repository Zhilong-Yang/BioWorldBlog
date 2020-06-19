using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries.GetAllTagName
{
    public class GetAllTagNameQuery : IRequest<TagsNameListDto>
    {
        public class GetAllTagNameQueryHandler : IRequestHandler<GetAllTagNameQuery, TagsNameListDto>
        {
            private readonly IApplicationDbContext _context;

            public GetAllTagNameQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<TagsNameListDto> Handle(GetAllTagNameQuery request,
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
}