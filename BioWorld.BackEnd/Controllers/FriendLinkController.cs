using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.FriendLink;
using BioWorld.Application.FriendLink.Commands.AddFriendLink;
using BioWorld.Application.FriendLink.Queries.GetAllFriendLink;
using BioWorld.Application.FriendLink.Queries.GetFriendLink;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class FriendLinkController : ApiController
    {
        public FriendLinkController(ILogger<ControllerBase> logger) : base(logger)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FriendLinkDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllFriendLinkQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FriendLinkDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetFriendLinkQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<FriendLinkDto>> Create(AddFriendLinkCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
