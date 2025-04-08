using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request.Payment
{
    public class PaymentRequest
    {
        public int OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
