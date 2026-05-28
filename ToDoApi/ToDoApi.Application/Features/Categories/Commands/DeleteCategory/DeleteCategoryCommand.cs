using MediatR;

namespace ToDoApi.Application.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(Guid Id, Guid UserId) : IRequest;
}


