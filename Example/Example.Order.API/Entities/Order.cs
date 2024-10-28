using Example.Order.API.Enums;

namespace Example.Order.API.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatu { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
