using UzbekCuisines.Application.Common.Utils;
using UzbekCuisines.Domain.Common;
using UzbekCuisines.Infrastructure.Common;
using UzbekCuisines.Infrastructure.Common.Interfaces;
using UzbekCuisines.Infrastructure.Persistence.Context;

namespace UzbekCuisines.Infrastructure.Repositories.Common;

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
