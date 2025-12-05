using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.Contracts
{
    public interface IServiceManager
    {
        // proberty signiture for each and every service that i have
        public IProductService ProductService { get; }
        public IBasketService BasketService { get; }
    }
}
