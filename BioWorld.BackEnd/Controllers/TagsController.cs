using System.Threading.Tasks;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Tag.Commands;
using BioWorld.Application.Tag.Commands.DeleteTag;
using BioWorld.Application.Tag.Commands.UpdateTag;
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
        public async Task<ActionResult<TagDto>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTagsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<TagDto>> GetAllName()
        {
            return Ok(await Mediator.Send(new GetAllTagsNameQuery()));
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<TagDto>> GetHot(int top)
        {
            return Ok(await Mediator.Send(new GetHotTagsQuery {Top = top}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTagByIdQuery {Id = id}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTagCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var Resp = await Mediator.Send(new DeleteTagCommand { Id = id });

            if (!Resp.IsSuccess)
            {
                return NotFound(Resp);
            }

            return NoContent();
        }
    }
}