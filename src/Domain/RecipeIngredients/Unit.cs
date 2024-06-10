using SharedKernel;

namespace Domain.RecipeIngredients;
public sealed record Unit
{
    public Unit(string? value)
    {
        Ensure.NotNullOrEmpty(value);

        Value = value;
    }
    public string Value { get; }
}
