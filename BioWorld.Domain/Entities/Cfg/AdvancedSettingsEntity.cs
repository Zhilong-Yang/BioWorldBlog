using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities.Cfg
{
    public class AdvancedSettingsEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public string DNSPrefetchEndpoint { get; set; }

        public string RobotsTxtContent { get; set; }

        public bool EnablePingBackSend { get; set; }

        public bool EnablePingBackReceive { get; set; }
    }
}