using System.Linq;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BioWorld.Infrastructure.Services
{
    public class BlogConfigService : IBlogConfigService
    {
        private readonly ILogger<BlogConfigService> _logger;

        private readonly IConfiguration _configuration;

        public GeneralSettingsEntity GeneralSettings { get; set; }

        public ContentSettingsEntity ContentSettings { get; set; }

        public NotificationSettingsEntity NotificationSettings { get; set; }

        public FeedSettingsEntity FeedSettings { get; set; }

        public WatermarkSettingsEntity WatermarkSettings { get; set; }

        public FriendLinksSettingsEntity FriendLinksSettings { get; set; }

        public AdvancedSettingsEntity AdvancedSettings { get; set; }

        private bool _hasInitialized;

        public BlogConfigService(ILogger<BlogConfigService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            GeneralSettings = new GeneralSettingsEntity();
            ContentSettings = new ContentSettingsEntity();
            NotificationSettings = new NotificationSettingsEntity();
            FeedSettings = new FeedSettingsEntity();
            WatermarkSettings = new WatermarkSettingsEntity();
            FriendLinksSettings = new FriendLinksSettingsEntity();
            AdvancedSettings = new AdvancedSettingsEntity();

            Initialize();
        }

        public void RequireRefresh()
        {
            _hasInitialized = false;
        }

        private void Initialize()
        {
            if (_hasInitialized) return;

            GetAllConfigurations();

            _hasInitialized = true;
        }


        private void GetAllConfigurations()
        {
            // GeneralSettings = _context.GeneralSettings.FirstOrDefault();
            // ContentSettings = _context.ContentSettings.FirstOrDefault();
            // NotificationSettings = _context.NotificationSettings.FirstOrDefault();
            // FeedSettings = _context.FeedSettings.FirstOrDefault();
            // WatermarkSettings = _context.WatermarkSettings.FirstOrDefault();
            // FriendLinksSettings = _context.FriendLinksSettings.FirstOrDefault();
            // AdvancedSettings = _context.AdvancedSettings.FirstOrDefault();
        }
    }
}