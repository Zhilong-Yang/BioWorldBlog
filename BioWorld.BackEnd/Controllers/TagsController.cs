using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioWorld.Application.Tag.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class TagsController: ApiController
    {
        public TagsController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagItemDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTagQuery { Id = id }));
        }

        // [Route("manage")]
        // public async Task<IActionResult> Manage()
        // {
        //     var response = await _tagService.GetAllTagsAsync();
        //     return response.IsSuccess ? View("~/Views/Admin/ManageTags.cshtml", response.Item) : ServerError();
        // }

    }
}
