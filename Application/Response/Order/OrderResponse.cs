using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.Order
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
