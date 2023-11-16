
using MediatR;
using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Application.Data;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.GetOrder;

internal sealed class GetOrderQueryHandler :
    IRequestHandler<GetOrderQuery, OrderResponce>
{
    private readonly IApplicationDbContext _context;
    private readonly IRepository<Order> _ordersRepository;

    public GetOrderQueryHandler(
        IApplicationDbContext context,
        IRepository<Order> ordersRepository)
    {
        _context = context;
        _ordersRepository = ordersRepository;
    }

    public async Task<OrderResponce> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orderResponce = await _ordersRepository
            .GetQueryable()
            .Where(o => o.Id == new OrderId(request.OrderId))
            .Select(order => new OrderResponce(
                order.Id.Value,
                order.CustomerId.Value,
                order.LineItems
                    .Select(li => new LineItemResponce(li.Id.Value, li.Price.Amount))
                    .ToList()))
            .SingleAsync(cancellationToken);

        return orderResponce;
    }
}
