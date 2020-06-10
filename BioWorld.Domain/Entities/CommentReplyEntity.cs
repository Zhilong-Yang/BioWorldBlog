using System;
using BioWorld.Domain.Common;

namespace BioWorld.Domain.Entities
{
    public class CommentReplyEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyTimeUtc { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public Guid? CommentId { get; set; }

        public CommentEntity Comment { get; set; }
    }
}