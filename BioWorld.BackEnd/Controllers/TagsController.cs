using System.Threading.Tasks;
using BioWorld.Application.Tag.Commands;
using BioWorld.Application.Tag.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class TagsController : ApiController
    {
        public TagsController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<TagItemDto>> GetAllTags()
        {
            return Ok(await Mediator.Send(new GetAllTagsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<TagItemDto>> GetAllTagsName()
        {
            return Ok(await Mediator.Send(new GetAllTagsNameQuery()));
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<TagItemDto>> GetHotTags(int top)
        {
            return Ok(await Mediator.Send(new GetHotTagsQuery {Top = top}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagItemDto>> GetTagById(int id)
        {
            return Ok(await Mediator.Send(new GetTagByIdQuery {Id = id}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTagById(int id, UpdateTagCommand command)
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