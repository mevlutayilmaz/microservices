using Example.Order.API.Contexts;
using Example.Order.API.Enums;
using Example.Shared.Events;
using MassTransit;

namespace Example.Order.API.Consumers
{
    public class PaymentCompletedEventConsumer : IConsumer<PaymentCompletedEvent>
    {
        readonly OrderAPIDbContext _context;

        public PaymentCompletedEventConsumer(OrderAPIDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            Entities.Order order = await _context.Orders.FindAsync(context.Message.OrderId);
            order.OrderStatu = OrderStatus.Completed;
            await _context.SaveChangesAsync();
        }
    }
}
