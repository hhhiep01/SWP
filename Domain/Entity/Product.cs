using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product: Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public SkinType SkinType { get; set; }

        public string ImageURL { get; set; }
        //
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
    public enum SkinType
    {   
        Normal = 1, // Da thường
        Oily = 2,     // Da dầu
        Dry = 3,      // Da khô
        Sensitive = 4, // Da nhạy cảm
          
    }
}
