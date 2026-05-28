namespace ToDoApi.Application.Dtos.TaskItemDtos
{
    public record TaskItemDto(Guid Id, string Title, string? Description, Guid? CategoryId, bool IsCompleted);

}
