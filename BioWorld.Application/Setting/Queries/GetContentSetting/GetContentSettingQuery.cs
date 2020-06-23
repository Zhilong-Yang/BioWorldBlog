using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Configuration;
using MediatR;
using Microsoft.Extensions.Options;

namespace BioWorld.Application.Setting.Queries.GetContentSetting
{
    public class GetContentSettingQuery :IRequest<ContentSettingsDto>
    {
        public class GetContentSettingQueryHandler : IRequestHandler<GetContentSettingQuery, ContentSettingsDto>
        {
            private readonly BlogConfigSetting _blogConfig;

            public GetContentSettingQueryHandler(IOptions<BlogConfigSetting> settings)
            {
                if (null != settings) _blogConfig = settings.Value;
            }

            public async Task<ContentSettingsDto> Handle(GetContentSettingQuery request, CancellationToken cancellationToken)
            {
                var vm = new ContentSettingsDto
                {
                    DisharmonyWords = _blogConfig.ContentSettings.DisharmonyWords,
                    EnableComments = _blogConfig.ContentSettings.EnableComments,
                    RequireCommentReview = _blogConfig.ContentSettings.RequireCommentReview,
                    EnableWordFilter = _blogConfig.ContentSettings.EnableWordFilter,
                    UseFriendlyNotFoundImage = _blogConfig.ContentSettings.UseFriendlyNotFoundImage,
                    PostListPageSize = _blogConfig.ContentSettings.PostListPageSize,
                    HotTagAmount = _blogConfig.ContentSettings.HotTagAmount,
                    EnableGravatar = _blogConfig.ContentSettings.EnableGravatar,
                    ShowCalloutSection = _blogConfig.ContentSettings.ShowCalloutSection,
                    CalloutSectionHtmlPitch = _blogConfig.ContentSettings.CalloutSectionHtmlPitch,
                    ShowPostFooter = _blogConfig.ContentSettings.ShowPostFooter,
                    PostFooterHtmlPitch = _blogConfig.ContentSettings.PostFooterHtmlPitch
                };
                return vm;
            }
        }
    }
}
