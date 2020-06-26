using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetContentSetting
{
    public class GetContentSettingQuery :IRequest<ContentSettingsDto>
    {
        public class GetContentSettingQueryHandler : IRequestHandler<GetContentSettingQuery, ContentSettingsDto>
        {
            private readonly IApplicationDbContext _context;

            public GetContentSettingQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ContentSettingsDto> Handle(GetContentSettingQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.ContentSettings.
                    Select(c => new ContentSettingsDto
                    {
                        Id = c.Id,
                        DisharmonyWords = c.DisharmonyWords,
                        EnableComments = c.EnableComments,
                        RequireCommentReview = c.RequireCommentReview,
                        EnableWordFilter = c.EnableWordFilter,
                        UseFriendlyNotFoundImage = c.UseFriendlyNotFoundImage,
                        PostListPageSize = c.PostListPageSize,
                        HotTagAmount = c.HotTagAmount,
                        EnableGravatar = c.EnableGravatar,
                        ShowCalloutSection = c.ShowCalloutSection,
                        CalloutSectionHtmlPitch = c.CalloutSectionHtmlPitch,
                        ShowPostFooter = c.ShowPostFooter,
                        PostFooterHtmlPitch = c.PostFooterHtmlPitch
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}
