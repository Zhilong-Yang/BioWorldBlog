using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public Guid PostId;

        public bool IsRecycle;
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
            var post = await _context.Post
                .Include(o=>o.PostPublish)
                .SingleOrDefaultAsync(o => o.Id == request.PostId, cancellationToken: cancellationToken);

            if (post == null)
            {
                throw new NotFoundException(nameof(PostEntity), request.PostId);
            }

            if (request.IsRecycle)
            {
                post.PostPublish.IsDeleted = true;
            }
            else
            {
                _context.Post.Remove(post);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}