
using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Application.Common;

public interface IGenericRepository<T> : IRepository<T>, IReadable<T> where T : BaseEntity
{
}
