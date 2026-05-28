namespace ToDoApi.Application.Dtos.TaskItemDtos
{
    public record TaskFilterDto(string? Search, Guid? CategoryId, int PageNumber = 1, int PageSize = 10);

}
