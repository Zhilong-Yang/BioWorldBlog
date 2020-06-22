using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.FriendLink.Queries.GetFriendLink
{
    public class GetFriendLinkQuery : IRequest<FriendLinkDto>
    {
        public Guid Id { get; set; }
    }

    public class GetFriendLinkQueryHandler : IRequestHandler<GetFriendLinkQuery, FriendLinkDto>
    {
        private readonly IApplicationDbContext _context;

        public GetFriendLinkQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FriendLinkDto> Handle(GetFriendLinkQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.FriendLink
                .Where(f => f.Id == request.Id)
                .Select(f => new FriendLinkDto
                {
                    Id = f.Id,
                    LinkUrl = f.LinkUrl,
                    Title = f.Title
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return item;
        }
    }
}
