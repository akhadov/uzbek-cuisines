﻿using UzbekCuisines.Domain.Common;

namespace UzbekCuisines.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
}
