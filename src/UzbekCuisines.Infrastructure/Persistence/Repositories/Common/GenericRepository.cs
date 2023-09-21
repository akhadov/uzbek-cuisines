
namespace UzbekCuisines.Infrastructure.Persistence.Repositories.Common;


public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
    where T : BaseEntity
{
    public GenericRepository(ApplicationDbContext context) : base(context)
    {
    }
    public virtual async Task<PagedList<T>> GetAllAsync(PaginationParams @params)
    {
        return await PagedList<T>.ToPagedListAsync(_dbSet.OrderBy(x => x.Id),
            @params.PageNumber, @params.PageSize);
    }
}
