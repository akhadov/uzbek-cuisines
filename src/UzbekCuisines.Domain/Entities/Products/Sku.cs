namespace UzbekCuisines.Domain.Entities.Products;

//Stock Keeping Unit
public record Sku
{
    private const int DefaultLenght = 15;

    private Sku(string value) => Value = value;

    public string Value { get; init; }

    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length != DefaultLenght)
        {
            return null;
        }
        return new Sku(value);
    }
}
