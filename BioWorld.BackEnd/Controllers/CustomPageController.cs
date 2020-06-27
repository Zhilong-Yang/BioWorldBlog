using System;
using System.Threading.Tasks;
using BioWorld.Application.CustomPage;
using BioWorld.Application.CustomPage.Queries.GetCustomePageById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class CustomPageController : ApiController
    {
        public CustomPageController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomPageDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetCustomPageByIdQuery() {PageId = id}));
        }
    }
}