using FluentValidation;

namespace ToDoApi.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
