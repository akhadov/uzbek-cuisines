using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Infrastructure.Common.Interfaces;

public interface IFindable<T> where T : BaseEntity
{
    public Task<T?> FindByIdAsync(long id);
}
