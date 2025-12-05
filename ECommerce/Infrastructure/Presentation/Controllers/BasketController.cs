using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.Dtos.BasketModule;
using Shared.Dtos.ProductModule;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class BasketController(IServiceManager serviceManager) : ApiControllerBase
    {
              [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> Get(string id)
            => Ok(await serviceManager.BasketService.GetBasketAsync(id));

        [HttpPost]
        public async Task<ActionResult<BasketDto>> Update(BasketDto basketDto)
            => Ok(await serviceManager.BasketService.CreateOrUpdateBasketAsync(basketDto));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await serviceManager.BasketService.DeleteBasketAsync(id);
            return NoContent();
        }
 
    }
}
