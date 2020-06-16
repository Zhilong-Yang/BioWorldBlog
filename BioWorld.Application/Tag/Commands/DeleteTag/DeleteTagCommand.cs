using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTagCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            // 1. Delete Post-Tag Association
            var postTags = await _context.PostTag
                .Where(pt => pt.TagId == request.Id
                             && !pt.Post.PostPublish.IsDeleted
                             && pt.Post.PostPublish.IsPublished)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (postTags == null)
            {
                throw new NotFoundException(nameof(PostTagEntity), request.Id);
            }

            _context.PostTag.RemoveRange(postTags);

            // 2. Delete Tag itself
            TagEntity tag = await _context.Tag.FindAsync(request.Id);

            if (tag == null)
            {
                throw new NotFoundException(nameof(TagEntity), request.Id);
            }

            _context.Tag.Remove(tag);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}