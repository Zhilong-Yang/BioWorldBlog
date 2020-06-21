namespace BioWorld.Application.Configuration
{
    public class NotificationSettings
    {
        public bool EnableEmailSending { get; set; }
        public bool SendEmailOnCommentReply { get; set; }
        public bool SendEmailOnNewComment { get; set; }
        public string AdminEmail { get; set; }
        public string EmailDisplayName { get; set; }
    }
}
