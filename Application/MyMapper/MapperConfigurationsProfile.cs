
using AutoMapper;
using Domain.Entity;

using Application.Response.UserAccount;

using Application.Request.User;
using Application.Request.Category;
using Application.Response.Category;
using Application.Request.Product;


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

            //Category
            CreateMap<CreateProductRequest, Product>();
          
        }
    }
}
