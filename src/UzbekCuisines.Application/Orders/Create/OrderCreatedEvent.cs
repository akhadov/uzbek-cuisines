using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.Create;

public record OrderCreatedEvent(Guid OrderId);

public record OrderConfirmationEmailSent(Guid OrderId);

public record OrderPaymentRequestSent(Guid OrderId);

public record SendOrderConfirmationEmail(Guid OrderId);

public record CreateOrderPaymentRequest(Guid OrderId);
