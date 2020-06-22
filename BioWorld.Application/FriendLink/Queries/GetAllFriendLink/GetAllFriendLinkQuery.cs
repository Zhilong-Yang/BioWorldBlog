using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.FriendLink.Queries.GetAllFriendLink
{
    public class GetAllFriendLinkQuery: IRequest<IReadOnlyList<FriendLinkDto>>
    {
        public class GetAllFriendLinkQueryHandler : IRequestHandler<GetAllFriendLinkQuery, IReadOnlyList<FriendLinkDto>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllFriendLinkQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IReadOnlyList<FriendLinkDto>> Handle(GetAllFriendLinkQuery request, CancellationToken cancellationToken)
            {
                var items = await _context.FriendLink
                    .Select(f => new FriendLinkDto
                    {
                        Id = f.Id,
                        LinkUrl = f.LinkUrl,
                        Title = f.Title
                    })
                    .ToListAsync(cancellationToken: cancellationToken);

                return items;
            }
        }
    }
}
