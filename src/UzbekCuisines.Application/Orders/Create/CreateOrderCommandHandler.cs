using MediatR;
using UzbekCuisines.Application.Data;
using UzbekCuisines.Domain.Entities.Customers;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;
    // from mediatr for sending notification
    private readonly IPublisher _publisher;
    private readonly IRepository<Customer> _customersRepository;
    private readonly IRepository<Order> _ordersRepository;

    public CreateOrderCommandHandler(
        IApplicationDbContext context, 
        IRepository<Customer> customersRepository, 
        IRepository<Order> ordersRepository)
    {
        _context = context;
        _customersRepository = customersRepository;
        _ordersRepository = ordersRepository;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customersRepository.GetByIdAsync(request.CustomerId);

        if (customer is null)
        {

            return;
        }

        var order = Order.Create(customer.Id);

        _ordersRepository.Insert(order);

        await _ordersRepository.SaveChangesAsync();

        await _publisher.Publish(new OrderCreatedEvent(order.Id), cancellationToken);
    }
}

