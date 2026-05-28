using MediatR;

namespace ToDoApi.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name, string Color, Guid UserId) : IRequest<Guid>;

}
