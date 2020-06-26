﻿namespace BioWorld.Application.Notification
{
    public class CommentReplyNotificationPayload
    {
        public CommentReplyNotificationPayload(
            string email,
            string commentContent,
            string title,
            string replyContentHtml,
            string postLink)
        {
            Email = email;
            CommentContent = commentContent;
            Title = title;
            ReplyContentHtml = replyContentHtml;
            PostLink = postLink;
        }

        public string Email { get; set; }

        public string CommentContent { get; set; }

        public string Title { get; set; }

        public string ReplyContentHtml { get; set; }

        public string PostLink { get; set; }
    }
}
