using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Post;
using BioWorld.Application.Post.Commands.CreatePost;
using BioWorld.Application.Post.Commands.DeletePost;
using BioWorld.Application.Post.Commands.PostHit;
using BioWorld.Application.Post.Commands.PostLike;
using BioWorld.Application.Post.Commands.RestoreDeletedPost;
using BioWorld.Application.Post.Queries.GetAllPostListItem;
using BioWorld.Application.Post.Queries.GetCountByCategoryId;
using BioWorld.Application.Post.Queries.GetCountVisiblePosts;
using BioWorld.Application.Post.Queries.GetMetaList;
using BioWorld.Application.Post.Queries.GetPostListItem;
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
            return Ok(await Mediator.Send(new GetAllPostListItemQuery() {Param = param}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetPostListItemQuery(){Id = id}));
        }

        [HttpGet("{status}")]
        public async Task<ActionResult<IReadOnlyList<PostMetaDataDto>>> GetMetaList(PostPublishStatus status)
        {
            return Ok(await Mediator.Send(new GetMetaListQuery() {PostPublishStatus = status}));
        }

        [HttpGet]
        public async Task<ActionResult<CountPostsDto>> Count()
        {
            return Ok(await Mediator.Send(new GetCountVisiblePostsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountPostsDto>> CountByCategoryId(Guid id)
        {
            return Ok(await Mediator.Send(new GetCountByCategoryIdQuery() {CategoryId = id}));
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<PostHitDto>> Hit(Guid postId)
        {
            return Ok(await Mediator.Send(new PostHitCommand() {PostId = postId}));
        }

        [HttpPost("{postId}")]
        public async Task<ActionResult<PostLikeDto>> Like(Guid postId)
        {
            return Ok(await Mediator.Send(new PostLikeCommand() {PostId = postId}));
        }

        [HttpPost]
        public async Task<CreatePostDto> Create(CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromQuery] bool isRecycle)
        {
            await Mediator.Send(new DeletePostCommand {PostId = id, IsRecycle = isRecycle});
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Restore(Guid id)
        {
            return Ok(await Mediator.Send(new RestoreDeletedPostCommand {PostId = id}));
        }
    }
}