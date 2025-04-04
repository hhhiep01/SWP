﻿using System;
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

        public double Price { get; set; }

        public SkinType SkinType { get; set; }

        public string ImageURL { get; set; }
        //
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
    public enum SkinType
    {
        Oily,
        Dry,
        Combination,
        Sensitive,
        Normal
    }
}
