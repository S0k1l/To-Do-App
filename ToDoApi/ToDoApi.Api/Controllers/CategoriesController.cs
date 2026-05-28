using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.Dtos.CategoryDtos;
using ToDoApi.Application.Features.Categories.Commands.CreateCategory;
using ToDoApi.Application.Features.Categories.Commands.DeleteCategory;
using ToDoApi.Application.Features.Categories.Commands.UpdateCategory;
using ToDoApi.Application.Features.Categories.Queries.GetCategories;
using ToDoApi.Application.Features.Categories.Queries.GetCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery(CurrentUserId));
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryQuery(id, CurrentUserId));
            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto dto)
        {
            var categoryId = await _mediator.Send(new CreateCategoryCommand(dto.Name, dto.Color, CurrentUserId));
            return CreatedAtAction(nameof(Get), new { categoryId }, categoryId);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCategoryDto dto)
        {
            var command = new UpdateCategoryCommand(id, dto.Name, dto.Color, CurrentUserId);

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id, CurrentUserId));
            return NoContent();
        }
    }
}
