using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Domain.Entities;

public class Food : BaseAuditableEntity
{
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    public decimal? Rate { get; set; }

    public long? CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public List<string> Tags { get; set; } = new();
}
