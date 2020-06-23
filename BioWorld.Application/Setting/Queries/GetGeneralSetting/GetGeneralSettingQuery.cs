using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Configuration;
using BioWorld.Application.Core;
using MediatR;
using Microsoft.Extensions.Options;

namespace BioWorld.Application.Setting.Queries.GetGeneralSetting
{
    public class GetGeneralSettingQuery : IRequest<GetGeneralSettingsDto>
    {
        public class GetAllPostListItemQueryHandler : IRequestHandler<GetGeneralSettingQuery, GetGeneralSettingsDto>
        {
            private readonly BlogConfigSetting _blogConfig;

            private readonly IDateTime _dateTimeResolver;

            public GetAllPostListItemQueryHandler(IOptions<BlogConfigSetting> settings, IDateTime dateTimeResolver)
            {
                if (null != settings) _blogConfig = settings.Value;
                _dateTimeResolver = dateTimeResolver;
            }

            public async Task<GetGeneralSettingsDto> Handle(GetGeneralSettingQuery request,
                CancellationToken cancellationToken)
            {
                var tzList = _dateTimeResolver.GetTimeZones().Select(t => new SelectListItemDto
                {
                    Text = t.DisplayName,
                    Value = t.Id
                }).ToList();

                var tmList = Utils.GetThemes().Select(t => new SelectListItemDto
                {
                    Text = t.Key,
                    Value = t.Value
                }).ToList();

                var vm = new GetGeneralSettingsDto
                {
                    LogoText = _blogConfig.GeneralSettings.LogoText,
                    MetaKeyword = _blogConfig.GeneralSettings.MetaKeyword,
                    MetaDescription = _blogConfig.GeneralSettings.MetaDescription,
                    CanonicalPrefix = _blogConfig.GeneralSettings.CanonicalPrefix,
                    SiteTitle = _blogConfig.GeneralSettings.SiteTitle,
                    Copyright = _blogConfig.GeneralSettings.Copyright,
                    SideBarCustomizedHtmlPitch = _blogConfig.GeneralSettings.SideBarCustomizedHtmlPitch,
                    FooterCustomizedHtmlPitch = _blogConfig.GeneralSettings.FooterCustomizedHtmlPitch,
                    OwnerName = _blogConfig.GeneralSettings.OwnerName,
                    OwnerDescription = _blogConfig.GeneralSettings.Description,
                    OwnerShortDescription = _blogConfig.GeneralSettings.ShortDescription,
                    SelectedTimeZoneId = _blogConfig.GeneralSettings.TimeZoneId,
                    SelectedUtcOffset = _dateTimeResolver.GetTimeSpanByZoneId(_blogConfig.GeneralSettings.TimeZoneId),
                    TimeZoneList = tzList,
                    SelectedThemeFileName = _blogConfig.GeneralSettings.ThemeFileName,
                    AutoDarkLightTheme = _blogConfig.GeneralSettings.AutoDarkLightTheme,
                    ThemeList = tmList
                };

                return vm;
            }
        }
    }
}