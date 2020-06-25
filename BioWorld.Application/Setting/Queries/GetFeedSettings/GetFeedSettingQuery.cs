using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetFeedSettings
{
    public class GetFeedSettingQuery : IRequest<FeedSettingsDto>
    {
        public class GetFeedSettingQueryHandler : IRequestHandler<GetFeedSettingQuery, FeedSettingsDto>
        {
            private readonly IApplicationDbContext _context;

            public GetFeedSettingQueryHandler(IApplicationDbContext context)
            {
                if (null != context) _context = context;
            }

            public async Task<FeedSettingsDto> Handle(GetFeedSettingQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.FeedSettings.Select(c => new FeedSettingsDto
                    {
                        AuthorName = c.AuthorName,
                        RssCopyright = c.RssCopyright,
                        RssDescription = c.RssDescription,
                        RssItemCount = c.RssItemCount,
                        RssTitle = c.RssTitle,
                        UseFullContent = c.UseFullContent
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}