using Example.Order.API.Contexts;
using Example.Order.API.Enums;
using Example.Shared.Events;
using MassTransit;

namespace Example.Order.API.Consumers
{
    public class StockNotReservedEventConsumer : IConsumer<StockNotReservedEvent>
    {
        readonly OrderAPIDbContext _context;

        public StockNotReservedEventConsumer(OrderAPIDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
            Entities.Order order = await _context.Orders.FindAsync(context.Message.OrderId);
            order.OrderStatu = OrderStatus.Failed;
            await _context.SaveChangesAsync();
        }
    }
}
