using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request.Order
{
    public class CreateOrderRequest
    {
        public string ShippingName { get; set; }   
        public string ShippingPhone { get; set; } 
        public string ShippingAddress { get; set; } 
    }
}
