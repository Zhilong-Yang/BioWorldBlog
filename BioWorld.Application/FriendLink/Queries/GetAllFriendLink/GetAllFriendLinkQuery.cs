using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.FriendLink.Queries.GetAllFriendLink
{
    public class GetAllFriendLinkQuery: IRequest<FriendLinkJsonDto>
    {
        public class GetAllFriendLinkQueryHandler : IRequestHandler<GetAllFriendLinkQuery, FriendLinkJsonDto>
        {
            private readonly IApplicationDbContext _context;

            public GetAllFriendLinkQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<FriendLinkJsonDto> Handle(GetAllFriendLinkQuery request, CancellationToken cancellationToken)
            {
                var items = await _context.FriendLink
                    .Select(f => new FriendLinkDto
                    {
                        Id = f.Id,
                        LinkUrl = f.LinkUrl,
                        Title = f.Title
                    })
                    .ToListAsync(cancellationToken: cancellationToken);

                return new FriendLinkJsonDto(items);
            }
        }
    }
}
