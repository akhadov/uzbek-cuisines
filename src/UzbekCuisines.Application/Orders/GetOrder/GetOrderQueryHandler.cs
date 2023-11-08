
using MediatR;
using Microsoft.EntityFrameworkCore;
using UzbekCuisines.Application.Data;

namespace UzbekCuisines.Application.Orders.GetOrder;

internal sealed class GetOrderQueryHandler :
    IRequestHandler<GetOrderQuery, OrderResponce>
{
    private readonly IApplicationDbContext _context;

    public GetOrderQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderResponce> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        //var orderResponce = await _context
        //    .Orders
        //    .Where(o => o.Id == new OrderId(request.OrderId))
        //    .Select(order => new OrderResponce(
        //        order.Id.Value,
        //        order.CustomerId.Value,
        //        order.LineItems
        //            .Select(li => new LineItemResponce(li.Id.Value, li.Price.Amount))
        //            .ToList()))
        //    .SingleAsync(cancellationToken);


        var orderSummaries = await _context
            .Database.SqlQuery<OrderSummary>(@$"
                SELECT o.Id AS OrderId, o.CustomerId, li.Id AS LineItemId, li.Price_Amount AS LineItemPrice
                FROM Orders AS o
                JOIN LineItems AS li ON li.OrderId = o.Id
                WHERE o.Id = {request.OrderId}")
            .ToListAsync(cancellationToken);

        var orderResponce = orderSummaries
            .GroupBy(o => o.OrderId)
            .Select(grp => new OrderResponce(
                grp.Key,
                grp.First().CustomerId,
                grp.Select(o => new LineItemResponce(o.LineItemId, o.LineItemPrice)).ToList()))
            .Single();

        return orderResponce;
    }

    private sealed record OrderSummary(
        Guid OrderId,
        Guid CustomerId,
        Guid LineItemId,
        decimal LineItemPrice);
}
