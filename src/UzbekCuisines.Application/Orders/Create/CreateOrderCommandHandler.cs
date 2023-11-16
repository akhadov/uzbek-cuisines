using MediatR;
using Rebus.Bus;
using UzbekCuisines.Application.Data;
using UzbekCuisines.Domain.Entities.Customers;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IBus _bus;

    public CreateOrderCommandHandler(
        IApplicationDbContext context,
        IBus bus)
    {
        _context = context;
        _bus = bus;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FindAsync(
            new CustomerId(request.CustomerId));

        if (customer is null)
        {

            return;
        }

        var order = Order.Create(customer.Id);

        _context.Orders.Add(order);

        await _context.SaveChangesAsync(cancellationToken);

        await _bus.Send(new OrderCreatedEvent(order.Id.Value));
    }
}

