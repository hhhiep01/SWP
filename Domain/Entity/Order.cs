using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Order : Base
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        //
        public int UserAccountId { get; set; }
        public  UserAccount UserAccount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
    public enum PaymentStatus
    {
        Unpaid,
        Paid,
        Refunded,
        Failed
    }
    public enum StatusOrder
    {
        Pending,
        Confirmed,
        Processing,
        Shipping,
        Delivered,
        Completed,
        Cancelled,
        Failed,
        Refunded
    } 
}
