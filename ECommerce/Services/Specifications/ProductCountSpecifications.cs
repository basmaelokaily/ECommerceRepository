using Domain.Entities.ProductModule;
using Shared.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductCountSpecifications : BaseSpecifications<Product, int>
    {
        public ProductCountSpecifications(ProductSpecParams parameters) : base(
            product =>
            //if it has no value
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value) &&
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim()))
            )
        {

        }
    }
}
