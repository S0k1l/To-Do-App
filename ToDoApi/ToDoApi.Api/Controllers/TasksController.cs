using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.Dtos.TaskItemDtos;
using ToDoApi.Application.Features.TaskItems.Commands.CreateTaskItem;
using ToDoApi.Application.Features.TaskItems.Commands.DeleteTaskItem;
using ToDoApi.Application.Features.TaskItems.Commands.ToggleTaskComplete;
using ToDoApi.Application.Features.TaskItems.Commands.UpdateTaskItem;
using ToDoApi.Application.Features.TaskItems.Queries.GatTaskItem;
using ToDoApi.Application.Features.TaskItems.Queries.GetTaskItems;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TaskFilterDto filter)
        {
            var tasks = await _mediator.Send(new GetTaskItemsQuery(CurrentUserId, filter));
            return Ok(tasks);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var taskItem = await _mediator.Send(new GetTaskItemQuery(id, CurrentUserId));
            return Ok(taskItem);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskItemDto dto)
        {
            var takItemId = await _mediator.Send(new CreateTaskItemCommand(dto.Title, dto.Description, CurrentUserId, dto.CategoryId));
            return CreatedAtAction(nameof(Get), new { takItemId }, takItemId);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTaskItemDto dto)
        {
            var command = new UpdateTaskItemCommand(id, CurrentUserId, dto.Title, dto.Description, dto.CategoryId);

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("{id:guid}/toggle-complete")]
        public async Task<IActionResult> ToggleComplete(Guid id)
        {
            await _mediator.Send(new ToggleTaskCompleteCommand(id, CurrentUserId));
            return NoContent();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTaskItemCommand(id, CurrentUserId));
            return NoContent();
        }
    }
}
