using FluentValidation;

namespace ToDoApi.Application.Features.TaskItems.Queries.GetTaskItems
{
    public class GetTaskItemsValidator : AbstractValidator<GetTaskItemsQuery>
    {
        public GetTaskItemsValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
