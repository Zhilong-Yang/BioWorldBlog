using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Post.Commands.PostHit
{
    public class PostHitCommand : IRequest<PostHitDto>
    {
        public Guid PostId { get; set; }
    }

    public class PostHitCommandHandler : IRequestHandler<PostHitCommand, PostHitDto>
    {
        private readonly IApplicationDbContext _context;

        public PostHitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostHitDto> Handle(PostHitCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostExtension.FindAsync(request.PostId);

            if (pp == null)
            {
                throw new NotFoundException(nameof(PostExtensionEntity), request.PostId);
            }

            pp.Hits += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return new PostHitDto()
            {
                Hits = pp.Hits
            };
        }
    }
}