
using MediatR;

namespace UzbekCuisines.Application.Orders.GetOrder;

public record GetOrderQuery(Guid OrderId) : IRequest<OrderResponce>;
