using AutoMapper;
using Domain.Entities.ProductModule;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappingprofile
{
    public class ProductProfile : Profile
    {
       public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>()
                .ForMember(D => D.BrandName, options => options.MapFrom(s => s.ProductBrand.Name))
                .ForMember(D => D.TypeName, options => options.MapFrom(s => s.ProductType.Name))
                .ForMember(D => D.PictureUrl, options => options.MapFrom<PictureUrlResolver>());
            CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<ProductType, TypeResultDto>();
        }
    }
}
