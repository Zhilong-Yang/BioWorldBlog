using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.FriendLink.Commands.AddFriendLink
{
    public class AddFriendLinkCommand : IRequest<FriendLinkDto>
    {
        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }

    public class AddFriendLinkCommandHandler : IRequestHandler<AddFriendLinkCommand, FriendLinkDto>
    {
        private readonly IApplicationDbContext _context;

        public AddFriendLinkCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FriendLinkDto> Handle(AddFriendLinkCommand request, CancellationToken cancellationToken)
        {
            if (!Uri.IsWellFormedUriString(request.LinkUrl, UriKind.Absolute))
            {
                throw new BadRequestException(
                    $"{nameof(request.LinkUrl)}InvalidParameter, current value: {request.LinkUrl}.");
            }

            var fdLink = new FriendLinkEntity
            {
                Id = Guid.NewGuid(),
                LinkUrl = request.LinkUrl,
                Title = request.Title
            };

            await _context.FriendLink.AddAsync(fdLink, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new FriendLinkDto()
            {
                Id = fdLink.Id,
                Title = fdLink.Title,
                LinkUrl = fdLink.LinkUrl
            };
        }
    }
}
