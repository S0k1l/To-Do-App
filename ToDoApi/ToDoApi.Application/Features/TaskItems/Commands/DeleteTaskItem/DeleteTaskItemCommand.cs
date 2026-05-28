using MediatR;

namespace ToDoApi.Application.Features.TaskItems.Commands.DeleteTaskItem
{
    public record DeleteTaskItemCommand(Guid Id, Guid UserId) : IRequest;
}
