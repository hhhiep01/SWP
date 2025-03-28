using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public SkinType SkinType { get; set; }

        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
    }
}
