using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetGeneralSetting
{
    public class GetGeneralSettingQuery : IRequest<GetGeneralSettingsDto>
    {
        public class GetAllPostListItemQueryHandler : IRequestHandler<GetGeneralSettingQuery, GetGeneralSettingsDto>
        {
            private readonly IApplicationDbContext _context;

            private readonly IDateTimeService _dateTimeServiceResolver;

            public GetAllPostListItemQueryHandler(IApplicationDbContext context, IDateTimeService dateTimeServiceResolver)
            {
                if (null != context) _context = context;
                _dateTimeServiceResolver = dateTimeServiceResolver;
            }

            public async Task<GetGeneralSettingsDto> Handle(GetGeneralSettingQuery request,
                CancellationToken cancellationToken)
            {
                var tzList = _dateTimeServiceResolver.GetTimeZones().Select(t => new SelectListItemDto
                {
                    Text = t.DisplayName,
                    Value = t.Id
                }).ToList();

                var tmList = Utils.GetThemes().Select(t => new SelectListItemDto
                {
                    Text = t.Key,
                    Value = t.Value
                }).ToList();

                var entity = await _context.GeneralSettings.
                    Select(c => new GetGeneralSettingsDto()
                    {
                        Id = c.Id,
                        LogoText = c.LogoText,
                        MetaKeyword = c.MetaKeyword,
                        MetaDescription = c.MetaDescription,
                        CanonicalPrefix = c.CanonicalPrefix,
                        SiteTitle = c.SiteTitle,
                        Copyright = c.Copyright,
                        SideBarCustomizedHtmlPitch = c.SideBarCustomizedHtmlPitch,
                        FooterCustomizedHtmlPitch = c.FooterCustomizedHtmlPitch,
                        OwnerName = c.OwnerName,
                        OwnerDescription = c.Description,
                        OwnerShortDescription = c.ShortDescription,
                        SelectedTimeZoneId = c.TimeZoneId,
                        SelectedUtcOffset = _dateTimeServiceResolver.GetTimeSpanByZoneId(c.TimeZoneId),
                        TimeZoneList = tzList,
                        SelectedThemeFileName = c.ThemeFileName,
                        AutoDarkLightTheme = c.AutoDarkLightTheme,
                        ThemeList = tmList
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}