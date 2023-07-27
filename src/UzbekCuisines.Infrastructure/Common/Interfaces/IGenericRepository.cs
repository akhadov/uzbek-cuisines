
using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Infrastructure.Common.Interfaces;

public interface IGenericRepository<T> : IRepository<T>, IReadable<T> where T : BaseEntity
{
}
