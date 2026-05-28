using FluentValidation;

namespace ToDoApi.Application.Features.TaskItems.Queries.GatTaskItem
{
    public class GatTaskItemValidator : AbstractValidator<GetTaskItemQuery>
    {
        public GatTaskItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
