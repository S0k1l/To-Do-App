namespace ToDoApi.Application.Dtos.TaskItemDtos
{
    public record CreateTaskItemDto(string Title, string? Description, Guid? CategoryId);

}
