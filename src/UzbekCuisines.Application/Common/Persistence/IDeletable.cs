using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Application.Common;

public interface IDeletable<T> where T : BaseEntity
{
    public Task<T> DeleteAsync(long id);
}
