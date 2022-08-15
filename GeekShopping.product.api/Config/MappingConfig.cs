using AutoMapper;
using GeekShopping.product.api.Data.ValueObjects;
using GeekShopping.product.api.Models;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.product.api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
            });
            return mappingConfig;
        }
    }
}
