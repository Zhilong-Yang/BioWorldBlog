using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Post.Commands.PostLike
{
    public class PostLikeCommand : IRequest<PostLikeDto>
    {
        public Guid PostId { get; set; }
    }

    public class PostLikeCommandHandler : IRequestHandler<PostLikeCommand, PostLikeDto>
    {
        private readonly IApplicationDbContext _context;

        public PostLikeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostLikeDto> Handle(PostLikeCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostExtension.FindAsync(request.PostId);

            if (pp == null)
            {
                throw new NotFoundException(nameof(PostExtensionEntity), request.PostId);
            }

            pp.Likes += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return new PostLikeDto()
            {
                Likes = pp.Likes
            };
        }
    }
}