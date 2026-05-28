using FluentValidation;

namespace ToDoApi.Application.Features.TaskItems.Commands.ToggleTaskComplete
{
    public class ToggleTaskCompleteValidator : AbstractValidator<ToggleTaskCompleteCommand>
    {
        public ToggleTaskCompleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
