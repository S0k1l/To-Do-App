using FluentValidation;

namespace ToDoApi.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesValidator : AbstractValidator<GetCategoriesQuery>
    {
        public GetCategoriesValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
