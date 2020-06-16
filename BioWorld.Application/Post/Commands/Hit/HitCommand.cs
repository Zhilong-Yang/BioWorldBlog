using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Common.Models;
using MediatR;

namespace BioWorld.Application.Post.Commands.Hit
{
    public class HitCommand : IRequest<Response>
    {
        public Guid PostId { get; set; }
    }

    public class HitCommandHandler : IRequestHandler<HitCommand, Response>
    {
        private readonly IApplicationDbContext _context;

        public HitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(HitCommand request, CancellationToken cancellationToken)
        {
            var pp = await _context.PostExtension.FindAsync(request.PostId);

            if (pp == null)
                return new FailedResponse((int) ResponseFailureCode.PostNotFound)
                {
                    Message = "PostNotFound"
                };

            pp.Hits += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessResponse()
            {
                Message = "Hit increased",
                Addition = new HitDto()
                {
                    Hits = pp.Hits
                }
            };
        }
    }
}