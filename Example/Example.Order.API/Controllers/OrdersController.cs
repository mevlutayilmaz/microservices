using Example.Order.API.Contexts;
using Example.Order.API.Entities;
using Example.Order.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly OrderAPIDbContext _context;

        public OrdersController(OrderAPIDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderVM createOrder)
        {
            Entities.Order order = new()
            {
                Id = Guid.NewGuid(),
                BuyerId = createOrder.BuyerId,
                OrderStatu = Enums.OrderStatus.Suspend,
                CreatedDate = DateTime.Now,
            };

            order.OrderItems = createOrder.OrderItems.Select(oi => new OrderItem()
            {
                ProductId = oi.ProductId,
                Price = oi.Price,
                Count = oi.Count
            }).ToList();

            order.TotalPrice = createOrder.OrderItems.Sum(oi => oi.Price * oi.Count);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
