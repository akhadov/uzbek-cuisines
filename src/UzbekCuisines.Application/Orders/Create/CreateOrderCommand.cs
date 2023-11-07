using MediatR;

namespace UzbekCuisines.Application.Orders.Create;

public record CreateOrderCommand : IRequest
{
    public Guid CustomerId { get; internal set; }
}
