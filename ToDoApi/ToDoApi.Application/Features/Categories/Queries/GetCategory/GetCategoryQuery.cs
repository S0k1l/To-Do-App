using MediatR;
using ToDoApi.Application.Dtos.CategoryDtos;

namespace ToDoApi.Application.Features.Categories.Queries.GetCategory
{
    public record GetCategoryQuery(Guid Id, Guid UserId) : IRequest<CategoryDto>;

}
