using System;

namespace BioWorld.Application.Comment.Commands.AddReply
{
    public class CommentReplyDetailDto
    {
        public DateTime ReplyTimeUtc { get; set; }
        public string ReplyContent { get; set; }
        public string ReplyContentHtml { get; set; }
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime PubDateUtc { get; set; }
    }
}
