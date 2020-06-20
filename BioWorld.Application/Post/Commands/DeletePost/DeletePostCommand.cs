using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Post.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public Guid PostId { get; set; }

        public bool IsRecycle { get; set; } = true;
    }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostPublish.FindAsync(request.PostId);

            if (pp == null)
            {
                throw new NotFoundException(nameof(PostPublishEntity), request.PostId);
            }

            if (request.IsRecycle)
            {
                pp.IsDeleted = true;
            }
            else
            {
                var p = await _context.Post.FindAsync(request.PostId);
                _context.Post.Remove(p);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}