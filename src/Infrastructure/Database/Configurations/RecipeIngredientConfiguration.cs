using Domain.RecipeIngredients;
using Domain.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;
internal sealed class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(r => r.Id);

        builder.ComplexProperty(
            r => r.Unit,
            b => b.Property(e => e.Value).HasColumnName("unit"));

        builder.Property(r => r.Amount);

        builder.HasOne<Recipe>()
            .WithMany()
            .HasForeignKey(recipeIngredient => recipeIngredient.RecipeId);

        builder.HasMany(r => r.Ingredients)
                .WithOne()
                .HasForeignKey(ingredient => ingredient.RecipeIngredientId);
    }
}
