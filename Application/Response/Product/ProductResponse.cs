using Application.Response.Category;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public SkinType SkinType { get; set; }

        public string ImageURL { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
