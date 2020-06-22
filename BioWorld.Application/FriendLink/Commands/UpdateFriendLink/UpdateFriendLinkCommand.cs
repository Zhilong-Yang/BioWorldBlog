using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.FriendLink.Commands.UpdateFriendLink
{
    public class UpdateFriendLinkCommand: IRequest<FriendLinkDto>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string LinkUrl { get; set; }
    }

    public class UpdateFriendLinkCommandHandler : IRequestHandler<UpdateFriendLinkCommand, FriendLinkDto>
    {
        private readonly IApplicationDbContext _context;

        public UpdateFriendLinkCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FriendLinkDto> Handle(UpdateFriendLinkCommand request, CancellationToken cancellationToken)
        {
            if (!Uri.IsWellFormedUriString(request.LinkUrl, UriKind.Absolute))
            {
                throw new BadRequestException(
                    $"{nameof(request.LinkUrl)}InvalidParameter, current value: {request.LinkUrl}.");
            }

            var fdlink = await _context.FriendLink.FindAsync(request.Id);

            if (null != fdlink)
            {
                fdlink.Title = request.Title;
                fdlink.LinkUrl = request.LinkUrl;

                await _context.SaveChangesAsync(cancellationToken);
            }

            return new FriendLinkDto()
            {
                Id = fdlink.Id,
                Title = fdlink.Title,
                LinkUrl = fdlink.LinkUrl
            };
        }
    }
}
