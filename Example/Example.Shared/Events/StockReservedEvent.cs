using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.Events
{
    public class StockReservedEvent
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
