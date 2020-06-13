using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioWorld.Application.Tag.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioWorld.BackEnd.Controllers
{
    public class TagsController: ApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TagItemDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTagQuery { Id = id }));
        }
    }
}
