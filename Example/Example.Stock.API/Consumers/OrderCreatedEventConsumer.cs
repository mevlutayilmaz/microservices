using Example.Shared.Events;
using Example.Shared.Messages;
using Example.Stock.API.Entities;
using Example.Stock.API.Services;
using MassTransit;
using MongoDB.Driver;

namespace Example.Stock.API.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        IMongoCollection<Entities.Stock> _stockCollection;
        public OrderCreatedEventConsumer(MongoDBService mongoDbService)
        {
            _stockCollection = mongoDbService.GetCollection<Entities.Stock>();
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            List<bool> stockResult = new();
            foreach (OrderItemMessage orderItem in context.Message.OrderItems)
            {
                stockResult.Add((await _stockCollection.FindAsync(s => s.ProductId == orderItem.ProductId && s.Count >= orderItem.Count)).Any());
            }

            if (stockResult.TrueForAll(sr => sr.Equals(true)))
            {
                foreach (OrderItemMessage orderItem in context.Message.OrderItems)
                {
                    Entities.Stock stock = await (await _stockCollection.FindAsync(s => s.ProductId == orderItem.ProductId)).FirstOrDefaultAsync();
                    stock.Count -= orderItem.Count;
                    await _stockCollection.FindOneAndReplaceAsync(s => s.ProductId == orderItem.ProductId, stock);
                }

                //Payment
            }
            else
            {
                
            }

            Console.WriteLine(context.Message.OrderId + " - " +  context.Message.BuyerId);
        }
    }
}
