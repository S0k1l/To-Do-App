using MediatR;

namespace ToDoApi.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public record CreateTaskItemCommand(string Title, string? Description, Guid UserId, Guid? CategoryId) : IRequest<Guid>;
}
