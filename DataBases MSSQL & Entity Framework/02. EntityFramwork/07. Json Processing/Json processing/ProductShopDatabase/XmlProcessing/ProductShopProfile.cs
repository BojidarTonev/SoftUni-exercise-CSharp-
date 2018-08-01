using ProductShop.App.Dtos.Import;

namespace ProductShop.App
{
    using AutoMapper;
    using Models;


    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
