using MediatR;
using ToDoApi.Application.Dtos;
using ToDoApi.Application.Dtos.TaskItemDtos;


namespace ToDoApi.Application.Features.TaskItems.Queries.GetTaskItems
{
    public record GetTaskItemsQuery(Guid UserId, TaskFilterDto Filter) : IRequest<PaginationDto<TaskItemDto>>;
}
