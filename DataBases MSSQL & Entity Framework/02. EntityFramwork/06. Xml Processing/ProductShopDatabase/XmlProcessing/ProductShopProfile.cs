using ProductShop.App.Dtos.Export;

namespace ProductShop.App
{
    using AutoMapper;
    using Dtos.Import;
    using Models;


    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto2>().ReverseMap();
        }
    }
}
