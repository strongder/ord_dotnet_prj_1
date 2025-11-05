using AppProduct.dtos.Category;
using AppProduct.dtos.Products;
using AppProduct.Dtos.User;
using AppProduct.Entity;
using AutoMapper;

namespace AppProduct;

public class AppProductApplicationAutoMapperProfile : Profile
{
    public AppProductApplicationAutoMapperProfile()
    {
        //map user
        CreateMap<AppUser, UserProfileDto>();
        CreateMap<CreateUserDto, AppUser>();
        CreateMap<UpdateUserDto, AppUser>();

        //map product   
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();

        //map category
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
    }
}
