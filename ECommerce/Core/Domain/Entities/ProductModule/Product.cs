using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductModule
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; } = null;
        public string PictureUrl { get; set; } = null;
        public decimal Price { get; set; }

        //one to many product and brand
        public ProductBrand ProductBrand { get; set; }
        public int BrandId { get; set; }

        public ProductType ProductType { get; set; }
        public int TypeId { get; set; }

    }
}
