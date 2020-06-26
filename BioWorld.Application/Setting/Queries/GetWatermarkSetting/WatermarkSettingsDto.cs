using System;

namespace BioWorld.Application.Setting.Queries.GetWatermarkSetting
{
    public class WatermarkSettingsDto
    {
        public Guid Id { get; set; }

        public bool IsEnabled { get; set; }

        public bool KeepOriginImage { get; set; }

        public int FontSize { get; set; }

        public string WatermarkText { get; set; }
    }
}