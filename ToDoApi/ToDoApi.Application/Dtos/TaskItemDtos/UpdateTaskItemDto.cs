namespace ToDoApi.Application.Dtos.TaskItemDtos
{
    public record UpdateTaskItemDto(Guid Id, string Title, string? Description, Guid? CategoryId);

}
