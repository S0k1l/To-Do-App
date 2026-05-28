using MediatR;
using ToDoApi.Application.Dtos.TaskItemDtos;

namespace ToDoApi.Application.Features.TaskItems.Queries.GatTaskItem
{
    public record GetTaskItemQuery(Guid Id, Guid UserId) : IRequest<TaskItemDto?>;

}
