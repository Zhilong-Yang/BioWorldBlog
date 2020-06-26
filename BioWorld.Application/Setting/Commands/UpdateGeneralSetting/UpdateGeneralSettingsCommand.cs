using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateGeneralSetting
{
    public class UpdateGeneralSettingsCommand : IRequest
    {
        public Guid Id { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalPrefix { get; set; }
        public string LogoText { get; set; }
        public string Copyright { get; set; }
        public string SiteTitle { get; set; }
        public string OwnerName { get; set; }
        public string OwnerDescription { get; set; }
        public string OwnerShortDescription { get; set; }
        public string SideBarCustomizedHtmlPitch { get; set; }
        public string FooterCustomizedHtmlPitch { get; set; }
        public string SelectedTimeZoneId { get; set; }
        public bool AutoDarkLightTheme { get; set; }
        public string SelectedThemeFileName { get; set; }
    }

    public class UpdateGeneralSettingsCommandHandler : IRequestHandler<UpdateGeneralSettingsCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        private readonly IDateTime _dateTime;

        public UpdateGeneralSettingsCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig, IDateTime dateTime)
        {
            _context = context;
            _blogConfig = blogConfig;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(UpdateGeneralSettingsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GeneralSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GeneralSettingsEntity), request.Id);
            }

            var settings = _blogConfig.GeneralSettings;

            settings.MetaKeyword = request.MetaKeyword;
            settings.MetaDescription = request.MetaDescription;
            settings.CanonicalPrefix = request.CanonicalPrefix;
            settings.SiteTitle = request.SiteTitle;
            settings.Copyright = request.Copyright;
            settings.LogoText = request.LogoText;
            settings.SideBarCustomizedHtmlPitch = request.SideBarCustomizedHtmlPitch;
            settings.FooterCustomizedHtmlPitch = request.FooterCustomizedHtmlPitch;
            settings.TimeZoneUtcOffset = _dateTime.GetTimeSpanByZoneId(request.SelectedTimeZoneId).ToString();
            settings.TimeZoneId = request.SelectedTimeZoneId;
            settings.ThemeFileName = request.SelectedThemeFileName;
            settings.OwnerName = request.OwnerName;
            settings.Description = request.OwnerDescription;
            settings.ShortDescription = request.OwnerShortDescription;
            settings.AutoDarkLightTheme = request.AutoDarkLightTheme;

            entity.MetaKeyword = request.MetaKeyword;
            entity.MetaDescription = request.MetaDescription;
            entity.CanonicalPrefix = request.CanonicalPrefix;
            entity.SiteTitle = request.SiteTitle;
            entity.Copyright = request.Copyright;
            entity.LogoText = request.LogoText;
            entity.SideBarCustomizedHtmlPitch = request.SideBarCustomizedHtmlPitch;
            entity.FooterCustomizedHtmlPitch = request.FooterCustomizedHtmlPitch;
            entity.TimeZoneUtcOffset = _dateTime.GetTimeSpanByZoneId(request.SelectedTimeZoneId).ToString();
            entity.TimeZoneId = request.SelectedTimeZoneId;
            entity.ThemeFileName = request.SelectedThemeFileName;
            entity.OwnerName = request.OwnerName;
            entity.Description = request.OwnerDescription;
            entity.ShortDescription = request.OwnerShortDescription;
            entity.AutoDarkLightTheme = request.AutoDarkLightTheme;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}