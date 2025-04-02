using Application.Response.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.Cart
{
    public class CartResponse
    {
        public int Id { get; set; }
        public List<CartItemResponse> Items { get; set; } = new();
    }
}
