using FluentValidation;

namespace Application.Categories.Delete;
internal sealed class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
{
    public RemoveCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryId)
            .NotEmpty();
    }
}
