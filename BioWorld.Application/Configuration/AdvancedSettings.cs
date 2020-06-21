namespace BioWorld.Application.Configuration
{
    public class AdvancedSettings
    {
        public string DNSPrefetchEndpoint { get; set; }

        public string RobotsTxtContent { get; set; }

        public bool EnablePingBackSend { get; set; }

        public bool EnablePingBackReceive { get; set; }
    }
}
