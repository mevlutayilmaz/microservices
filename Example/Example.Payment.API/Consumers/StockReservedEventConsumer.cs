using Example.Shared.Events;
using MassTransit;

namespace Example.Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            if (true)
            {
                PaymentCompletedEvent paymentCompletedEvent = new() { OrderId = context.Message.OrderId };
                await _publishEndpoint.Publish(paymentCompletedEvent);

                Console.WriteLine("Ödeme başarılı");
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "Ödeme işlemi başarısız!"
                };
                await _publishEndpoint.Publish(paymentFailedEvent);

                Console.WriteLine("Ödeme başarısız");
            }
        }
    }
}
