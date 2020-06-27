using System;
using System.Threading.Tasks;
using BioWorld.Application.CustomPage;
using BioWorld.Application.CustomPage.Queries.GetCustomePageById;
using BioWorld.Application.CustomPage.Queries.GetCustomPageBySlug;
using BioWorld.Application.CustomPage.Queries.GetCustomPageListSegment;
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

        [HttpGet("{slug}")]
        public async Task<ActionResult<CustomPageDto>> GetBySlug(string slug)
        {
            return Ok(await Mediator.Send(new GetCustomPageBySlugQuery() {Slug = slug}));
        }

        [HttpGet]
        public async Task<ActionResult<CustomPageSegmentJsonDto>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCustomPageListSegmentQuery()));
        }
    }
}