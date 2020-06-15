using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries
{
    public class GetAllTagsQuery : IRequest<IReadOnlyList<TagDto>>
    {
        public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IReadOnlyList<TagDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAllTagsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<TagDto>> Handle(GetAllTagsQuery request,
                CancellationToken cancellationToken)
            {
                var tags = await _context.Tag
                    .AsNoTracking()
                    .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return tags;
            }
        }
    }
}