﻿using Domain.Categories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public void Insert(Category category)
    {
        context.Categories.Add(category);
    }

    public void Remove(Category category)
    {
        context.Categories.Remove(category);
    }

    public void Update(Category category)
    {
        context.Categories.Update(category);
    }
}
