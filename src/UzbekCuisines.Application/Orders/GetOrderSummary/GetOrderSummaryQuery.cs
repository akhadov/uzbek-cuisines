using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.GetOrderSummary;

public record GetOrderSummaryQuery(Guid OrderId) : IRequest<OrderSummary?>;
