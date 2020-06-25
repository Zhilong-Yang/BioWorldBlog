using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetFriendLinksSetting
{
    public class GetFriendLinksSettingQuery : IRequest<FriendLinksSettingsDto>
    {
        public class
            GetFriendLinksSettingQueryHandler : IRequestHandler<GetFriendLinksSettingQuery, FriendLinksSettingsDto>
        {
            private readonly IApplicationDbContext _context;

            public GetFriendLinksSettingQueryHandler(IApplicationDbContext context)
            {
                if (null != context) _context = context;
            }

            public async Task<FriendLinksSettingsDto> Handle(GetFriendLinksSettingQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.FriendLinksSettings
                    .Select(c => new FriendLinksSettingsDto
                    {
                        ShowFriendLinksSection = c.ShowFriendLinksSection
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}