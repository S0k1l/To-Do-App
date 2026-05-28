using MediatR;

namespace ToDoApi.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(Guid Id, string Name, string Color, Guid UserId) : IRequest;
}
