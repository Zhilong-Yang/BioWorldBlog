using System.Threading.Tasks;
using BioWorld.Application.Comment.Commands.AddComment;
using BioWorld.Application.Comment.Commands.AddReply;
using BioWorld.Application.Comment.Commands.ApproveComment;
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
    }
}
