using MediatR;

namespace ToDoApi.Application.Features.TaskItems.Commands.ToggleTaskComplete
{
    public record ToggleTaskCompleteCommand(Guid Id, Guid UserId) : IRequest;

}
