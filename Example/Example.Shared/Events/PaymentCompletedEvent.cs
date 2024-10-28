using Example.Shared.Events.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.Events
{
    public class PaymentCompletedEvent : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
