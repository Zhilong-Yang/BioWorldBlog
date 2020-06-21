using System;

namespace BioWorld.Application.Comment.Commands.AddReply
{
    public class AddReplyCmdDto
    {
        public Guid CommentId { get; set; }
        public string ReplyContent { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
    }
}
