using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Post.Commands.Like
{
    public class LikeCommand : IRequest<LikeDto>
    {
        public Guid PostId { get; set; }
    }

    public class LikeCommandHandler : IRequestHandler<LikeCommand, LikeDto>
    {
        private readonly IApplicationDbContext _context;

        public LikeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LikeDto> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostExtension.FindAsync(request.PostId);

            if (pp == null)
            {
                throw new NotFoundException(nameof(PostExtensionEntity), request.PostId);
            }

            pp.Likes += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return new LikeDto()
            {
                Likes = pp.Likes
            };
        }
    }
}