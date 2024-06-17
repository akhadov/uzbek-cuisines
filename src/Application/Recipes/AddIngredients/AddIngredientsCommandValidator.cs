using FluentValidation;

namespace Application.Recipes.AddIngredients;
internal sealed class AddIngredientsCommandValidator : AbstractValidator<AddIngredientsCommand>
{
    public AddIngredientsCommandValidator()
    {
        RuleFor(i => i.Ingredients)
            .NotEmpty().WithErrorCode(RecipeErrorCodes.AddIngredients.MissingIngredients);
    }
}
