using System.Threading.Tasks;
using BioWorld.Application.Tag.Commands.DeleteTag;
using BioWorld.Application.Tag.Commands.UpdateTag;
using BioWorld.Application.Tag.Queries;
using BioWorld.Application.Tag.Queries.GetAllTag;
using BioWorld.Application.Tag.Queries.GetAllTagName;
using BioWorld.Application.Tag.Queries.GetHotTag;
using BioWorld.Application.Tag.Queries.GetTag;
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
            return Ok(await Mediator.Send(new GetAllTagQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<TagDto>> GetAllName()
        {
            return Ok(await Mediator.Send(new GetAllTagNameQuery()));
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<TagDto>> GetHot(int top)
        {
            return Ok(await Mediator.Send(new GetHotTagQuery {Top = top}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTagQuery {Id = id}));
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
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTagCommand {Id = id});
            return NoContent();
        }
    }
}