using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Abstraction.Contracts;
using Services.Specifications;
using Shared.Dtos;
using Shared.Enums;
using Shared.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    internal class ProductService(IUniteOfWork _uniteOfWork, IMapper _mapper ) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            //1. Retrive All Brands ---> uniteOfWork
            var brands = await _uniteOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            //2. Mapping from Product Brand to BrandResultDto
            var brandsResult = _mapper.Map<IEnumerable<BrandResultDto>>(brands);
            //3. return 
            return brandsResult;
        }

        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecParams parameters)
        {
            var products = await _uniteOfWork.GetRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications(parameters));
            var productsResult = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            var pageSize = productsResult.Count();
            var totalCount = await _uniteOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecifications(parameters));
            return new PaginatedResult<ProductResultDto>(parameters.PageIndex, pageSize, totalCount, productsResult);
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await _uniteOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeResultDto>>(types);
            return typesResult;
        }

        public async Task<ProductResultDto> GetProductAsync(int id)
        {
            var product = await _uniteOfWork.GetRepository<Product, int>().GetAsync(new ProductWithBrandAndTypeSpecifications(id));
            var productResult = _mapper.Map<ProductResultDto>(product);
            return productResult;   
        }
    }
}
