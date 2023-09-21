using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Application.Common.Utils;
using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Application.Common;

public interface IReadable<T> where T : BaseEntity
{
    public Task<PagedList<T>> GetAllAsync(PaginationParams @params);
}
