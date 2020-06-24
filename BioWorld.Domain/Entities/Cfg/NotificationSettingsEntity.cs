using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities.Cfg
{
    public class NotificationSettingsEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public bool EnableEmailSending { get; set; }
        public bool SendEmailOnCommentReply { get; set; }
        public bool SendEmailOnNewComment { get; set; }
        public string AdminEmail { get; set; }
        public string EmailDisplayName { get; set; }
    }
}