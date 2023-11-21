using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Application.Data;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.GetOrderSummary;

internal sealed class GetOrderSummaryQueryHandler
    : IRequestHandler<GetOrderSummaryQuery, OrderSummary?>
{
    private readonly IApplicationDbContext _context;

    public GetOrderSummaryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderSummary?> Handle(GetOrderSummaryQuery request, CancellationToken cancellationToken)
    {
        return await _context.OrderSummaries
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
    }
}
