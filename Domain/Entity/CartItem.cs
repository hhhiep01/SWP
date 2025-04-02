using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CartItem: Base
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; }

        // Navigation properties
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
