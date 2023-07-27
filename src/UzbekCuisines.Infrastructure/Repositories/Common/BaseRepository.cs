using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Domain.Common;
using UzbekCuisines.Infrastructure.Common.Interfaces;
using UzbekCuisines.Infrastructure.Persistence.Context;

namespace UzbekCuisines.Infrastructure.Repositories.Common;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected ApplicationDbContext _dbContext;
    protected DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> DeleteAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        else throw new NullReferenceException("Not found entity to remove");
    }

    public virtual async Task<T?> FindByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T> UpdateAsync(long id, T entity)
    {
        var previousEntity = await _dbSet.FindAsync(id);
        if (previousEntity is not null)
        {
            entity.Id = id;
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        else throw new NullReferenceException("Not found entity to update");
    }
}
