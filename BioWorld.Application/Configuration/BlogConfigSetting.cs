namespace BioWorld.Application.Configuration
{
    public class BlogConfigSetting
    {
        public ContentSettings ContentSettings { get; set; }
        public GeneralSettings GeneralSettings { get; set; }

        public NotificationSettings NotificationSettings { get; set; }
        public FeedSettings FeedSettings { get; set; }
        public WatermarkSettings WatermarkSettings { get; set; }
        public FriendLinksSettings FriendLinksSettings { get; set; }
        public AdvancedSettings AdvancedSettings { get; set; }

        public BlogConfigSetting()
        {
            ContentSettings = new ContentSettings();
            GeneralSettings = new GeneralSettings();
            NotificationSettings = new NotificationSettings();
            FeedSettings = new FeedSettings();
            WatermarkSettings = new WatermarkSettings();
            FriendLinksSettings = new FriendLinksSettings();
            AdvancedSettings = new AdvancedSettings();
        }
    }
}
