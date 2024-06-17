using Domain.Categories;
using Domain.Dishes;
using Domain.Recipes;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;
internal sealed class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(recipe => recipe.Id);

        builder.ComplexProperty(
            recipe => recipe.Description,
            description => description.Property(d => d.Value).HasColumnName("description"));

        builder.Property(recipe => recipe.PrepTime)
            .IsRequired();

        builder.Property(recipe => recipe.CookTime)
            .IsRequired();

        builder.Property(recipe => recipe.Servings)
            .IsRequired();

        builder.Property(recipe => recipe.ImagePath)
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(recipe => recipe.UserId);

        builder.HasOne<Dish>()
            .WithMany()
            .HasForeignKey(recipe => recipe.DishId);

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(recipe => recipe.CategoryId);

        builder.HasMany(r => r.Ingredients)
                .WithOne()
                .HasForeignKey(ingredient => ingredient.RecipeId);
    }
}
