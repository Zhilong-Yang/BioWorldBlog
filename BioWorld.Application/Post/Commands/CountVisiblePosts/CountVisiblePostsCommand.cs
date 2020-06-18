using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Commands.CountVisiblePosts
{
    public class CountVisiblePostsCommand : IRequest<CountVisiblePostsDto>
    {
        public class CountVisiblePostsCommandHandler : IRequestHandler<CountVisiblePostsCommand, CountVisiblePostsDto>
        {
            private readonly IApplicationDbContext _context;

            public CountVisiblePostsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<CountVisiblePostsDto> Handle(CountVisiblePostsCommand request,
                CancellationToken cancellationToken)
            {
                var count = await _context.PostPublish
                    .Where(p => p.IsPublished && !p.IsDeleted)
                    .CountAsync(cancellationToken);
                return new CountVisiblePostsDto(count);
            }
        }
    }
}