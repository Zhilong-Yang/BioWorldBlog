using System;
using System.Threading.Tasks;
using BioWorld.Application.Comment.Commands.AddReply;
using BioWorld.Application.Comment.Queries.GetPagedComment;

namespace BioWorld.Application.Common.Interface
{
    public interface INotificationClient
    {
        Task SendNewCommentNotificationAsync(CommentListItemWithReplyDto model,
            Func<string, string> funcCommentContentFormat);

        Task SendCommentReplyNotificationAsync(CommentReplyDetailDto model, string postLink);
    }
}