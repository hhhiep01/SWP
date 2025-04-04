
using AutoMapper;
using Domain.Entity;

using Application.Response.UserAccount;

using Application.Request.User;
using Application.Request.Category;
using Application.Response.Category;
using Application.Request.Product;
using Application.Response.Product;
using Application.Response.Cart;
using Application.Response.CartItem;


namespace Application.MyMapper
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
          
            //UserAccount
            //CreateMap<UserProfileResponse, UserAccount>();
            CreateMap<UpdateUserRequest, UserAccount>();
            CreateMap<UserAccount, UserProfileResponse>();
            CreateMap<UserAccount, AccountResponse>();

            //Category
            CreateMap<AddCategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<UpdateCategoryRequest, Category>();

            //Product
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            //Cart
            CreateMap<Cart, CartResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));

            //CartItem
            CreateMap<CartItem, CartItemResponse>()
                .ForMember(dest => dest.ProductResponse, opt => opt.MapFrom(src => src.Product));



        }
    }
}
