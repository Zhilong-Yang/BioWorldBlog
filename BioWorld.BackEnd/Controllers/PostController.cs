using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Post.Commands.Hit;
using BioWorld.Application.Post.Commands.Like;
using BioWorld.Application.Post.Queries.GetAllPostListItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class PostController : ApiController
    {
        public PostController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PostListItemDto>>> GetAll([FromQuery] Paging param)
        {
            return Ok(await Mediator.Send(new GetAllPostListItemQuery() { Param = param }));
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<HitDto>> Hit(Guid postId)
        {
            return Ok(await Mediator.Send(new HitCommand() {PostId = postId}));
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<LikeDto>> Like(Guid postId)
        {
            return Ok(await Mediator.Send(new LikeCommand() { PostId = postId }));
        }
    }
}