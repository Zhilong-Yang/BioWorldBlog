using System.Threading.Tasks;
using BioWorld.Application.Tag.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class TagsController: ApiController
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

        [HttpGet]
        public async Task<ActionResult<TagItemDto>> GetHotTags()
        {
            return Ok(await Mediator.Send(new GetAllTagsNameQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagItemDto>> GetTagById(int id)
        {
            return Ok(await Mediator.Send(new GetTagByIdQuery { Id = id }));
        }
    }
}
