using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Post.Commands.CountVisiblePosts;
using BioWorld.Application.Post.Commands.CreatePost;
using BioWorld.Application.Post.Commands.DeletePost;
using BioWorld.Application.Post.Commands.PostHit;
using BioWorld.Application.Post.Commands.PostLike;
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

        [HttpGet]
        public async Task<ActionResult<CountVisiblePostsDto>> Count()
        {
            return Ok(await Mediator.Send(new CountVisiblePostsCommand()));
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<PostHitDto>> Hit(Guid postId)
        {
            return Ok(await Mediator.Send(new PostHitCommand() {PostId = postId}));
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<PostLikeDto>> Like(Guid postId)
        {
            return Ok(await Mediator.Send(new PostLikeCommand() { PostId = postId }));
        }

        [HttpPost]
        public async Task<CreatePostDto> Create(CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id,[FromQuery] bool isRecycle)
        {
            await Mediator.Send(new DeletePostCommand { PostId = id , IsRecycle = isRecycle });
            return NoContent();
        }
    }
}