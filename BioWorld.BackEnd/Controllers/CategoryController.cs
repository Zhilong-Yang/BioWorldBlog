using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioWorld.Application.Category;
using BioWorld.Application.Category.Commands.CreateCategory;
using BioWorld.Application.Category.Commands.DeleteCategory;
using BioWorld.Application.Category.Commands.UpdateCategory;
using BioWorld.Application.Category.Queries.GetAllCategoryListItem;
using BioWorld.Application.Category.Queries.GetCategoryById;
using BioWorld.Application.Category.Queries.GetCategoryByName;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class CategoryController : ApiController
    {
        public CategoryController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCategoryQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery(){ Id  = id }));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CategoryDto>> GetByName(string name)
        {
            return Ok(await Mediator.Send(new GetCategoryByNameQuery() { CategoryName = name }));
        }

        [HttpPost]
        public async Task<CreateCategoryDto> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}