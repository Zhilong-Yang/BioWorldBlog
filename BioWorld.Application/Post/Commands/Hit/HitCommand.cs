using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Post.Commands.Hit
{
    public class HitCommand : IRequest<HitDto>
    {
        public Guid PostId { get; set; }
    }

    public class HitCommandHandler : IRequestHandler<HitCommand, HitDto>
    {
        private readonly IApplicationDbContext _context;

        public HitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HitDto> Handle(HitCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostExtension.FindAsync(request.PostId);

            if (pp == null)
            {
                throw new NotFoundException(nameof(PostExtensionEntity), request.PostId);
            }

            pp.Hits += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return new HitDto()
            {
                Hits = pp.Hits
            };
        }
    }
}