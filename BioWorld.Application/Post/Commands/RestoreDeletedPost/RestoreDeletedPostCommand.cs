using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Commands.RestoreDeletedPost
{
    public class RestoreDeletedPostCommand : IRequest
    {
        public Guid PostId;
    }

    public class RestoreDeletedPostCommandHandler : IRequestHandler<RestoreDeletedPostCommand>
    {
        private readonly IApplicationDbContext _context;

        public RestoreDeletedPostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RestoreDeletedPostCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostPublish.FindAsync(request.PostId);

            if (pp == null)
            {
                throw new NotFoundException(nameof(PostPublishEntity), request.PostId);
            }
            
            pp.IsDeleted = false; 
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}