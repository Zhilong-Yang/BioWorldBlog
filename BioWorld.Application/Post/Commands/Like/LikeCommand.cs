using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Post.Commands.Hit;
using MediatR;

namespace BioWorld.Application.Post.Commands.Like
{
    public class LikeCommand : IRequest<Response>
    {
        public Guid PostId { get; set; }
    }

    public class LikeCommandHandler : IRequestHandler<LikeCommand, Response>
    {
        private readonly IApplicationDbContext _context;

        public LikeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostExtension.FindAsync(request.PostId);

            if (pp == null)
                return new FailedResponse((int) ResponseFailureCode.PostNotFound)
                {
                    Message = "Post Not Found"
                };

            pp.Likes += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessResponse()
            {
                Message = "You Have Rated",
                Addition = new LikeDto()
                {
                    Likes = pp.Likes
                }
            };
        }
    }
}