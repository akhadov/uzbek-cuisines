namespace Application.Categories.GetById;
public sealed record CategoryResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }
}
