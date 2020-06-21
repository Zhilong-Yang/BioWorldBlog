using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Comment.Commands.AddComment;
using BioWorld.Application.Comment.Commands.AddReply;
using BioWorld.Application.Comment.Commands.ApproveComment;
using BioWorld.Application.Comment.Commands.DeleteComment;
using BioWorld.Application.Comment.Queries.GetPagedComment;
using BioWorld.Application.Comment.Queries.GetSelectedCommentsOfPost;
using BioWorld.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class CommentController : ApiController
    {
        public CommentController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<ActionResult<CommentListItemDto>> Create(AddCommentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<CommentReplyDetailDto>> CreateReply(AddReplyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult> ToggleApprovalStatus(ApproveToggleCommentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteComments(DeleteCommentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CommentListItemWithReplyDto>>> GetAll([FromQuery] Paging param)
        {
            return Ok(await Mediator.Send(new GetPagedCommentQuery() { Param = param }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<PostCommentListItemDto>>> GetSelectedCommentsOfPost(Guid id)
        {
            return Ok(await Mediator.Send(new GetSelectedCommentsQuery() { PostId = id }));
        }
    }
}
