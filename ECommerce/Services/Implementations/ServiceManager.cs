using AutoMapper;
using Domain.Contracts;
using Services.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ServiceManager(IUniteOfWork uniteOfWork, IMapper mapper) : IServiceManager
    {
        private readonly Lazy<IProductService> productService = new Lazy<IProductService>(() => new ProductService(uniteOfWork, mapper));
        public IProductService ProductService => productService.Value;
    }
}
