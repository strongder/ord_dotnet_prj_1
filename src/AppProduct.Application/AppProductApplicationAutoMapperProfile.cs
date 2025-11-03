using AppProduct.dtos.Products;
using AppProduct.Entity;
using AutoMapper;

namespace AppProduct;

public class AppProductApplicationAutoMapperProfile : Profile
{
    public AppProductApplicationAutoMapperProfile()
    {
        //map user
        CreateMap<AppUser, AppUserDto>();
        CreateMap<AppUserDto, AppUser>();

        //map product   
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
    }
}
