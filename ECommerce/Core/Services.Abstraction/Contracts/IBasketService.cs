using Shared.Dtos.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.Contracts
{
    public interface IBasketService
    {
        public Task<BasketDto> GetBasketAsync(string id);

        public Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket);

        public Task<bool> DeleteBasketAsync(string id); 
    }
}
