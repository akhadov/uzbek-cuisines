using SharedKernel;

namespace Domain.Recipes.Events;
public sealed record RecipeCreatedDomainEvent(Guid RecipeId) : IDomainEvent;
