using Application.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.OrderDetail
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        //
        public ProductResponse Product { get; set; }
    }
}
