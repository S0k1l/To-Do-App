using FluentValidation;

namespace ToDoApi.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryValidator : AbstractValidator<GetCategoryQuery>
    {
        public GetCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
