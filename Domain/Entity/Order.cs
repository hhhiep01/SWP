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
        public decimal TotalPrice { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public string ShippingName { get; set; }  
        public string ShippingPhone { get; set; } 
        public string ShippingAddress { get; set; }
        //
        public int UserAccountId { get; set; }
        public  UserAccount UserAccount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Payment> Payments { get; set; }

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
        Refunded,
        AwaitingPayment
    } 
}
