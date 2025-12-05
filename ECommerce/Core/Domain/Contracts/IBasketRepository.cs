using Domain.Entities.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
        // get basket by id
        public Task<CustomerBasket> GetBasketAsync(string id);

        //delete basket
        public Task<bool> DeleteBasketAsync(string id);

        //create or update basket
        public Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? timeToLive = null);
    }
}
