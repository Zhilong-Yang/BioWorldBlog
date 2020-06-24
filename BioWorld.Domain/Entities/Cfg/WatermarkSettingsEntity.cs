using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities.Cfg
{
    public class WatermarkSettingsEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public bool IsEnabled { get; set; }
        public bool KeepOriginImage { get; set; }
        public int FontSize { get; set; }
        public string WatermarkText { get; set; }
    }
}