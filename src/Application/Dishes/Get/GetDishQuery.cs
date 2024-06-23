using Application.Abstractions.Messaging;

namespace Application.Dishes.Get;
public sealed record GetDishQuery(Guid DishId) : IQuery<DishResponse>;
