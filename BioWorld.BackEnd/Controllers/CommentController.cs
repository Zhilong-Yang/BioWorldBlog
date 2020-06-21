using System.Threading.Tasks;
using BioWorld.Application.Comment.Commands.AddComment;
using BioWorld.Application.Comment.Commands.AddReply;
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
        public async Task<CommentListItemDto> Create(AddCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<CommentReplyDetailDto> CreateReply(AddReplyCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
