namespace ToDoApi.Application.Dtos.CategoryDtos
{
    public record CreateCategoryDto(string Name, string Color, Guid UserId);

}
