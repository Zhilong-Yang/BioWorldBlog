using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetCountByCategoryId
{
    public class GetCountByCategoryIdQuery : IRequest<CountPostsDto>
    {
        public Guid CategoryId { get; set; }
    }

    public class GetCountByCategoryIdQueryHandler : IRequestHandler<GetCountByCategoryIdQuery, CountPostsDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCountByCategoryIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CountPostsDto> Handle(GetCountByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var count = await _context.PostCategory
            .Where(c => c.CategoryId == request.CategoryId)
            .CountAsync(cancellationToken);

            return new CountPostsDto(count);
        }
    }
}