using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries
{
    public class GetTagQuery : IRequest<TagItemDto>
    {
        public int Id { get; set; }

        public class GetTagQueryHandler : IRequestHandler<GetTagQuery, TagItemDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetTagQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TagItemDto> Handle(GetTagQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Tag
                    .Where(e => e.Id == request.Id)
                    .ProjectTo<TagItemDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken); ;
            
                return vm;
            }
        }
    }
}
