namespace UzbekCuisines.Domain.Entities;

public class Food : Auditable
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? Rate { get; set; }

    public long? CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
