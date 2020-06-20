using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetCountVisiblePosts
{
    public class GetCountVisiblePostsQuery : IRequest<CountPostsDto>
    {
        public class CountVisiblePostsQueryHandler : IRequestHandler<GetCountVisiblePostsQuery, CountPostsDto>
        {
            private readonly IApplicationDbContext _context;

            public CountVisiblePostsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<CountPostsDto> Handle(GetCountVisiblePostsQuery request,
                CancellationToken cancellationToken)
            {
                var count = await _context.PostPublish
                    .Where(p => p.IsPublished && !p.IsDeleted)
                    .CountAsync(cancellationToken);
                return new CountPostsDto(count);
            }
        }
    }
}