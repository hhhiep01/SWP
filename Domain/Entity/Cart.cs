using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Cart: Base
    {
        public int Id { get; set; }
        //
        public int UserId { get; set; }
        public UserAccount UserAccount { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
