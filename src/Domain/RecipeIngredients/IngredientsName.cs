using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed record IngredientsName
{
    public IngredientsName(string? value)
    {
        Ensure.NotNullOrEmpty(value);

        Value = value;
    }

    public string Value { get; }
}
