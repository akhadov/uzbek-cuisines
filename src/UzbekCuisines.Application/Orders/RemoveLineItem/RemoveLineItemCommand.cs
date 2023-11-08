using MediatR;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.RemoveLineItem;

public record RemoveLineItemCommand(OrderId OrderId, LineItemId LineItemId) : IRequest;
