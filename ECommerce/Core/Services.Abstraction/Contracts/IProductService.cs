using Shared.Dtos;
using Shared.Enums;
using Shared.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.Contracts
{
    public interface IProductService
    {
        //get all products
        public Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecParams parameters);
        //get product
        public Task<ProductResultDto> GetProductAsync(int id);
        //get all brands
        public Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
        //get all Types
        public Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
    }
}
