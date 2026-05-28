using FluentValidation;

namespace ToDoApi.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();

        }
    }
}
