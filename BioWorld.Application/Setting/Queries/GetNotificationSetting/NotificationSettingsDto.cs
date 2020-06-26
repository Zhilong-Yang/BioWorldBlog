using System;

namespace BioWorld.Application.Setting.Queries.GetNotificationSetting
{
    public class NotificationSettingsDto
    {
        public Guid Id { get; set; }

        public bool EnableEmailSending { get; set; }

        public bool SendEmailOnCommentReply { get; set; }

        public bool SendEmailOnNewComment { get; set; }

        public string AdminEmail { get; set; }

        public string EmailDisplayName { get; set; }
    }
}