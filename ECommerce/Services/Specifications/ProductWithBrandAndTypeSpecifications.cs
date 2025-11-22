using Domain.Entities.ProductModule;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        //query = _dbCOntext.Set<Product>().where(p => p.ID == 5).include(p => p.productBrand).include(p => p.productType)
        public ProductWithBrandAndTypeSpecifications(ProductSortingOptions sort) : base(null)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            switch(sort)
            {
                case ProductSortingOptions.NameAsc:
                    SetOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    SetOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PricAsc:
                    SetOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    SetOrderByDesc(p => p.Price);
                    break;
                default:
                    SetOrderBy(p => p.Name);
                    break;

            }
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}
