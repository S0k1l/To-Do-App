namespace ToDoApi.Application.Dtos.CategoryDtos
{
    public record UpdateCategoryDto(Guid Id, string Name, string Color, Guid UserId);

}
