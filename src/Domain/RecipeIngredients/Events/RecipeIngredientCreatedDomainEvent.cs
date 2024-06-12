using SharedKernel;

namespace Domain.RecipeIngredients.Events;
public sealed record RecipeIngredientCreatedDomainEvent(Guid RecipeIngredientId) : IDomainEvent;
