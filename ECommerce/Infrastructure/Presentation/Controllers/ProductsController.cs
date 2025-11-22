using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.Dtos;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        #region GetAllProducts
        [HttpGet] // GET: api/products/products
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProducts(ProductSortingOptions sort)
            => Ok(await serviceManager.ProductService.GetAllProductsAsync(sort));
        #endregion

        #region GetAllBrands
        [HttpGet("Brands")] // GET: api/products/brands
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
            => Ok(await serviceManager.ProductService.GetAllBrandsAsync());
        #endregion

        #region GetAllTypes
        [HttpGet("Types")] // GET: api/products/types
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
           => Ok(await serviceManager.ProductService.GetAllTypesAsync());
        #endregion

        #region GetProduct
        [HttpGet("{id:int}")] // GET: api/products/products/5
        public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
            => Ok(await serviceManager.ProductService.GetProductAsync(id));
        #endregion

    }
}
