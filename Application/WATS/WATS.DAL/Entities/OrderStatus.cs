using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
   public class OrderStatus
    {
        public Int64 RId { get; set; }

        public Int64 OrderStatusId { get; set; }

        public string OrdersStatus { get; set; }

        public bool IsActive { get; set; }
    }
}
