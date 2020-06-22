using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.FriendLink.Commands.DeleteFriendLink
{
    public class DeleteFriendLinkCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteFriendLinkCommandHandler : IRequestHandler<DeleteFriendLinkCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFriendLinkCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFriendLinkCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.FriendLink.FindAsync(request.Id);

            if (null != item)
            {
                _context.FriendLink.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}