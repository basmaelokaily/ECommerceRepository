using Domain.Entities.ProductModule;
using Shared.Enums;
using Shared.types;
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
        public ProductWithBrandAndTypeSpecifications(ProductSpecParams parameters) : base(
            product => 
            //if it has no value
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value) && 
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) && 
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim()))
            )
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            switch(parameters.Sort)
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

            ApplyPagination(parameters.PageIndex, parameters.PageSize); 
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}
