using System;
using System.Threading.Tasks;
using BioWorld.Application.Comment.Commands.AddComment;
using BioWorld.Application.Comment.Commands.AddReply;
using BioWorld.Application.Comment.Commands.ApproveComment;
using BioWorld.Application.Comment.Commands.DeleteComment;
using BioWorld.Application.Comment.Queries.GetCountComments;
using BioWorld.Application.Comment.Queries.GetPagedComment;
using BioWorld.Application.Comment.Queries.GetSelectedCommentsOfPost;
using BioWorld.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class CommentController : ApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentController(ILogger<ControllerBase> logger, 
            IHttpContextAccessor httpContextAccessor) : base(logger)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult<CommentListItemDto>> Create(AddCommentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<CommentReplyDetailDto>> CreateReply(AddReplyCommand command)
        {
            command.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
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
        public async Task<ActionResult<CommentListItemWithReplyJsonDto>> GetAll([FromQuery] Paging param)
        {
            return Ok(await Mediator.Send(new GetPagedCommentQuery() {Param = param}));
        }

        [HttpGet]
        public async Task<ActionResult<CommentCountDto>> CountComments()
        {
            return Ok(await Mediator.Send(new GetCountCommentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostCommentListItemJsonDto>> GetSelectedCommentsOfPost(Guid id)
        {
            return Ok(await Mediator.Send(new GetSelectedCommentsQuery() {PostId = id}));
        }
    }
}