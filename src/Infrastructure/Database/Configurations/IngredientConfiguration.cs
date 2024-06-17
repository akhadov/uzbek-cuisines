using Domain.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;
internal sealed class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(ingredient => ingredient.Id);

        builder.ComplexProperty(ingredient => ingredient.Name,
            x => x.Property(e => e.Value).HasColumnName("name"));

        builder.ComplexProperty(
            r => r.Unit,
            b => b.Property(e => e.Value).HasColumnName("unit"));

        builder.Property(r => r.Amount);
    }
}
