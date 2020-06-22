using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Commands.DeleteRecycled
{
    public class DeleteRecycledCommand : IRequest
    {
        public class DeleteRecycledCommandHandler : IRequestHandler<DeleteRecycledCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteRecycledCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteRecycledCommand request, CancellationToken cancellationToken)
            {
                var posts = await _context.Post
                    .Where(p => p.PostPublish.IsDeleted)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                
                _context.Post.RemoveRange(posts);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}