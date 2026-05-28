using FluentValidation;

namespace ToDoApi.Application.Features.TaskItems.Commands.UpdateTaskItem
{
    public class UpdateTaskItemValidator : AbstractValidator<UpdateTaskItemCommand>
    {
        public UpdateTaskItemValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
