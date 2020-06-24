using BioWorld.Domain.Entities.Cfg;

namespace BioWorld.Application.Common.Interface
{
    public interface IBlogConfigService
    {
        GeneralSettingsEntity GeneralSettings { get; set; }
        ContentSettingsEntity ContentSettings { get; set; }
        NotificationSettingsEntity NotificationSettings { get; set; }
        FeedSettingsEntity FeedSettings { get; set; }
        WatermarkSettingsEntity WatermarkSettings { get; set; }
        FriendLinksSettingsEntity FriendLinksSettings { get; set; }
        AdvancedSettingsEntity AdvancedSettings { get; set; }
        void RequireRefresh();
    }
}