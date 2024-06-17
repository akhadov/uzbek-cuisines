﻿namespace Domain.Categories;
public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Category category);

    void Update(Category category);

    void Remove(Category category);
}
