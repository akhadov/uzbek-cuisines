using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzbekCuisines.Application.Orders.Create;

public class OrderCreateSaga : Saga<OrderCreateSagaData>,
    IAmInitiatedBy<OrderCreatedEvent>,
    IHandleMessages<OrderConfirmationEmailSent>,
    IHandleMessages<OrderPaymentRequestSent>
{
    //for sent messages over the queue
    private readonly IBus _bus;

    public OrderCreateSaga(IBus bus)
    {
        _bus = bus;
    }

    protected override void CorrelateMessages(ICorrelationConfig<OrderCreateSagaData> config)
    {
        config.Correlate<OrderCreatedEvent>(m => m.OrderId, s => s.OrderId);
        config.Correlate<OrderConfirmationEmailSent>(m => m.OrderId, s => s.OrderId);
        config.Correlate<OrderPaymentRequestSent>(m => m.OrderId, s => s.OrderId);
    }

    public async Task Handle(OrderCreatedEvent message)
    {
        if(!IsNew)
        {
            return;
        }

        await _bus.Send(new SendOrderConfirmationEmail(message.OrderId));
    }

    public async Task Handle(OrderConfirmationEmailSent message)
    {
        Data.ConfirmationEmailSent = true;

        await _bus.Send(new CreateOrderPaymentRequest(message.OrderId));

    }

    public Task Handle(OrderPaymentRequestSent message)
    {
        Data.PaymentRequestSent = true;

        //ccomplate saga with rebus
        MarkAsComplete();

        return Task.CompletedTask;
    }

}
