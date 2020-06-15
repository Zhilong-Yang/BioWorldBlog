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
        public async Task<ActionResult<TagItemDto>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTagsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<TagItemDto>> GetAllName()
        {
            return Ok(await Mediator.Send(new GetAllTagsNameQuery()));
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<TagItemDto>> GetHot(int top)
        {
            return Ok(await Mediator.Send(new GetHotTagsQuery {Top = top}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagItemDto>> Get(int id)
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
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTagCommand { Id = id });

            return NoContent();
        }
    }
}