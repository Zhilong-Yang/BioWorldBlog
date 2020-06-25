using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Application.Setting.Queries.GetAdvanceSetting
{
    public class AdvanceSettingDto
    {
        public string DNSPrefetchEndpoint { get; set; }

        public string RobotsTxtContent { get; set; }

        public bool EnablePingbackSend { get; set; }

        public bool EnablePingbackReceive { get; set; }
    }
}
