using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using Rebus.Handlers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Rebus.Bus;

namespace UzbekCuisines.Application.Orders.Create;

internal sealed class SendOrderConfirmationEmailHandler
    : IHandleMessages<SendOrderConfirmationEmail>
{
    private readonly ILogger<SendOrderConfirmationEmailHandler> _logger;
    private readonly IBus _bus;

    public SendOrderConfirmationEmailHandler(ILogger<SendOrderConfirmationEmailHandler> logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public async Task Handle(SendOrderConfirmationEmail message)
    {
        _logger.LogInformation("Sending order confirmation {@OrderId}", message.OrderId);

        await Task.Delay(2000);

        _logger.LogInformation("Order confirmation sent {@OrderId}", message.OrderId);

        await _bus.Send(new OrderConfirmationEmailSent(message.OrderId));
    }
}
