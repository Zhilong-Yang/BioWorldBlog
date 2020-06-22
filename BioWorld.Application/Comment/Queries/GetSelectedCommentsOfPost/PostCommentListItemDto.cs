using System;
using System.Collections.Generic;
using BioWorld.Application.Comment.Queries.GetPagedComment;

namespace BioWorld.Application.Comment.Queries.GetSelectedCommentsOfPost
{
    public class PostCommentListItemDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime CreateOnUtc { get; set; }

        public string CommentContent { get; set; }

        public IReadOnlyList<CommentReplyDigestDto> CommentReplies { get; set; }
    }

    public class PostCommentListItemJsonDto
    {
        public IReadOnlyList<PostCommentListItemDto> PostCommentList { get; set; }

        public PostCommentListItemJsonDto(IReadOnlyList<PostCommentListItemDto> postCommentList)
        {
            PostCommentList = postCommentList;
        }
    }
}
