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
    public class GetTagByIdQuery : IRequest<TagDto>
    {
        public int Id { get; set; }

        public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetTagByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Tag
                    .AsNoTracking()
                    .Where(e => e.Id == request.Id)
                    .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);
                ;

                return vm;
            }
        }
    }
}