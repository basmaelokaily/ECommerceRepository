using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.Dtos;
using Shared.Enums;
using Shared.types;
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
        //once the parameter number is greater than three its best to define a user defined type
        //instead of sending all of that 
        public async Task<ActionResult<PaginatedResult<ProductResultDto>>> GetAllProducts([FromQuery]ProductSpecParams parameters)
            => Ok(await serviceManager.ProductService.GetAllProductsAsync(parameters));
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
