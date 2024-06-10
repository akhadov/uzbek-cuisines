using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.RecipeIngredients.Events;
public sealed record RecipeIngredientCreatedDomainEvent(Guid RecipeIngredientId) : IDomainEvent;
