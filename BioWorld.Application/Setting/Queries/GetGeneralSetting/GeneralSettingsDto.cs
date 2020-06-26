using System;
using System.Collections.Generic;

namespace BioWorld.Application.Setting.Queries.GetGeneralSetting
{
    public class SelectListItemDto
    {
        public string Text { get; set; }

        public string Value { get; set; }
    }

    public class GetGeneralSettingsDto
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

        public TimeSpan SelectedUtcOffset { get; set; }

        public string SelectedTimeZoneId { get; set; }

        public List<SelectListItemDto> TimeZoneList { get; set; }
        
        public bool AutoDarkLightTheme { get; set; }

        public string SelectedThemeFileName { get; set; }

        public List<SelectListItemDto> ThemeList { get; set; }
    }
}
