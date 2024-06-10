using SharedKernel;

namespace Domain.RecipeIngredients.Events;
public sealed record IngredientCreatedDomainEvent(Guid IngredientId) : IDomainEvent;
