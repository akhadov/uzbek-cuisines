using FluentValidation;

namespace Application.RecipeIngredients.CreateIngredient;
internal sealed class AddIngredientsCommandValidator : AbstractValidator<AddIngredientsCommand>
{
    public AddIngredientsCommandValidator()
    {
        RuleFor(i => i.Ingredients)
            .NotEmpty();
    }
}
