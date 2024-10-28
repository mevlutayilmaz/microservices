﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.Events
{
    public class PaymentFailedEvent
    {
        public Guid OrderId { get; set; }
        public string Message { get; set; }
    }
}