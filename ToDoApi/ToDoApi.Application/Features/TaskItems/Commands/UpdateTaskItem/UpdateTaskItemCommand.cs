using MediatR;

namespace ToDoApi.Application.Features.TaskItems.Commands.UpdateTaskItem
{
    public record UpdateTaskItemCommand(Guid Id, Guid UserId, string Title, string? Description, Guid? CategoryId) : IRequest;
}
