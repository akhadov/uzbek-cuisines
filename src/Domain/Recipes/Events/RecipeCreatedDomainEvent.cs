using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Recipes.Events;
public sealed record RecipeCreatedDomainEvent(Guid RecipeId) : IDomainEvent;
