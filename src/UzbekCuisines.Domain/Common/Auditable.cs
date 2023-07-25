using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UzbekCuisines.Domain.Common;

public abstract class Auditable : BaseEntity
{
    //public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    //public string? CreatedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    //public string? LastModifiedBy { get; set; }
}
