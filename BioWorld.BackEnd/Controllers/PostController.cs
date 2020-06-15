using System.Threading.Tasks;
using BioWorld.Application.Common;
using BioWorld.Application.Post.Queries;
using BioWorld.Application.Tag.Queries;
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
        public async Task<ActionResult<PostListItemDto>> GetAll([FromQuery] BlogResourceParameters param)
        {
            return Ok(await Mediator.Send(new GetAllPostListItemQuery(){ Param = param}));
        }
    }
}