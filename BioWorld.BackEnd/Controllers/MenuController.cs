using System;
using System.Threading.Tasks;
using BioWorld.Application.Menu;
using BioWorld.Application.Menu.Commands.CreateMenu;
using BioWorld.Application.Menu.Queries.GetMenu;
using BioWorld.Application.Menu.Queries.GetMenus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class MenuController : ApiController
    {
        public MenuController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<ActionResult<MenuDto>> Create(CreateMenuCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<MenuJsonDto>> GetAll()
        {
            return Ok(await Mediator.Send(new GetMenusQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetMenuQuery(){Id = id}));
        }
    }
}