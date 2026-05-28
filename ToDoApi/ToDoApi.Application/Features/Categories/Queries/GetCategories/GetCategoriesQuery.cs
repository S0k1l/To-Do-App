using MediatR;
using ToDoApi.Application.Dtos.CategoryDtos;

namespace ToDoApi.Application.Features.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery(Guid UserId) : IRequest<List<CategoryDto>>;

}
