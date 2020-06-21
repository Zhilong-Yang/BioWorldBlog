using System;
using System.Collections.Generic;

namespace BioWorld.Application.Comment.Queries.GetPagedComment
{
    public class CommentReplyDigestDto
    {
        public DateTime ReplyTimeUtc { get; set; }
        public string ReplyContent { get; set; }
        public string ReplyContentHtml { get; set; }
    }
    public class CommentListItemWithReplyDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string IpAddress { get; set; }
        public string CommentContent { get; set; }
        public string PostTitle { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreateOnUtc { get; set; }

        public IReadOnlyList<CommentReplyDigestDto> CommentRepliesDto { get; set; }
    }
}
