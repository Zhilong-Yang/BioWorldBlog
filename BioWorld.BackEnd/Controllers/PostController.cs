﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Post;
using BioWorld.Application.Post.Commands.CreatePost;
using BioWorld.Application.Post.Commands.DeletePost;
using BioWorld.Application.Post.Commands.DeleteRecycled;
using BioWorld.Application.Post.Commands.EditPost;
using BioWorld.Application.Post.Commands.PostHit;
using BioWorld.Application.Post.Commands.PostLike;
using BioWorld.Application.Post.Commands.RestoreDeletedPost;
using BioWorld.Application.Post.Queries.GetAllPostListItem;
using BioWorld.Application.Post.Queries.GetArchived;
using BioWorld.Application.Post.Queries.GetArchiveList;
using BioWorld.Application.Post.Queries.GetCountByCategoryId;
using BioWorld.Application.Post.Queries.GetCountVisiblePosts;
using BioWorld.Application.Post.Queries.GetDraftPreview;
using BioWorld.Application.Post.Queries.GetInsights;
using BioWorld.Application.Post.Queries.GetMetaByDate;
using BioWorld.Application.Post.Queries.GetMetaList;
using BioWorld.Application.Post.Queries.GetPostByDate;
using BioWorld.Application.Post.Queries.GetPostListItem;
using BioWorld.Application.Post.Queries.GetPostsByTag;
using BioWorld.Application.Post.Queries.GetRawContent;
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PostListItemDto>>> GetArchived([FromQuery] int year, [FromQuery] int month)
        {
            return Ok(await Mediator.Send(new GetArchivedQuery() { Year = year, Month = month}));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ArchiveDto>>> GetArchiveList()
        {
            return Ok(await Mediator.Send(new GetArchiveListQuery() ));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<PostSlugDto>>> GetDraftPreview(Guid id)
        {
            return Ok(await Mediator.Send(new GetDraftPreviewQuery() {  PostId= id }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<GetPostsByTagDto>>> GetByTagId(int id)
        {
            return Ok(await Mediator.Send(new GetPostsByTagQuery() {TagId = id}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetPostListItemQuery() {Id = id}));
        }

        [HttpGet("{status}")]
        public async Task<ActionResult<IReadOnlyList<PostMetaDataDto>>> GetMetaList(PostPublishStatus status)
        {
            return Ok(await Mediator.Send(new GetMetaListQuery() {PostPublishStatus = status}));
        }

        [HttpGet("{insights}")]
        public async Task<ActionResult<IReadOnlyList<GetInsightsDto>>> GetInsights(PostInsightsType insights)
        {
            return Ok(await Mediator.Send(new GetInsightsQuery() {InsightsType = insights}));
        }

        [HttpGet]
        public async Task<ActionResult<PostRawContentDto>> GetRawContent([FromQuery] int year,
            [FromQuery] int month,
            [FromQuery] int day,
            [FromQuery] string slug)
        {
            return Ok(await Mediator.Send(new GetRawContentQuery()
            {
                Year = year,
                Month = month,
                Day = day,
                Slug = slug
            }));
        }

        [HttpGet]
        public async Task<ActionResult<PostSlugDto>> GetPostByDateSlug([FromQuery] int year,
            [FromQuery] int month,
            [FromQuery] int day,
            [FromQuery] string slug)
        {
            return Ok(await Mediator.Send(new GetPostByDateQuery()
            {
                Year = year,
                Month = month,
                Day = day,
                Slug = slug
            }));
        }

        [HttpGet]
        public async Task<ActionResult<PostSlugMetaDto>> GetMetaByDateSlug([FromQuery] int year,
            [FromQuery] int month,
            [FromQuery] int day,
            [FromQuery] string slug)
        {
            return Ok(await Mediator.Send(new GetMetaByDateQuery()
            {
                Year = year,
                Month = month,
                Day = day,
                Slug = slug
            }));
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
        public async Task<ActionResult<CreatePostDto>> Create(CreatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromQuery] bool isRecycle)
        {
            await Mediator.Send(new DeletePostCommand {PostId = id, IsRecycle = isRecycle});
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRecycled()
        {
            await Mediator.Send(new DeleteRecycledCommand());
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Restore(Guid id)
        {
            return Ok(await Mediator.Send(new RestoreDeletedPostCommand {PostId = id}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, EditPostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}