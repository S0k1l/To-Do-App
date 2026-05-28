using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Application.Dtos.TaskItemDtos;

namespace ToDoApi.Application.Features.TaskItems.Queries.GatTaskItem
{
    public class GetTaskItemHandler : IRequestHandler<GetTaskItemQuery, TaskItemDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskItemHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItemDto?> Handle(GetTaskItemQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _context.TaskItems
                .Where(ti => ti.Id == request.Id && ti.UserId == request.UserId)
                .Select(ti => new TaskItemDto(ti.Id, ti.Title, ti.Description, ti.CategoryId, ti.IsCompleted))
                .FirstOrDefaultAsync();

            if (taskItem == null)
                throw new Exception("Task not found!");

            return taskItem;
        }
    }
}
