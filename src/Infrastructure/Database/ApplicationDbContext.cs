using System.Data;
using Application.Abstractions.Data;
using Domain.Categories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    //public DbSet<Dish> Dishes { get; set; }
    //public DbSet<Instruction> Instructions { get; set; }
    //public DbSet<Ingredient> Ingredients { get; set; }
    //public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    //public DbSet<Recipe> Recipes { get; set; }
    //public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        return (await Database.BeginTransactionAsync()).GetDbTransaction();
    }
}
