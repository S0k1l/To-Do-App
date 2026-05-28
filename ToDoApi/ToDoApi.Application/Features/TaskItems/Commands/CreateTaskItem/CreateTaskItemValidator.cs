using FluentValidation;

namespace ToDoApi.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemValidator : AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();

        }
    }
}
