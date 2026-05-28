using FluentValidation;

namespace ToDoApi.Application.Features.TaskItems.Commands.DeleteTaskItem
{
    public class DeleteTaskItemValidator : AbstractValidator<DeleteTaskItemCommand>
    {
        public DeleteTaskItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
