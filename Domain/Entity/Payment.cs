using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Payment : Base
    {
        public int Id { get; set; }
        public decimal AmountPaid { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        //
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
    public enum PaymentStatus
    {
        Unpaid,
        Paid,
        Refunded,
        Failed,
        Pending
    }
    public enum PaymentMethod
    {
        VnPay,      // Thẻ tín dụng
        Cash             // Tiền mặt
    }

}
