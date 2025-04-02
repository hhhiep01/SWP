using Application.Interface;
using Application.Request.Category;
using Application.Response;
using Application.Response.Category;
using AutoMapper;
using Domain;
using Domain.Entity;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IClaimService _claimService;
        private IEmailService _emailService;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, AppSetting appSettings, IClaimService claimService, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _claimService = claimService;
            _emailService = emailService;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddCategoryAsync(AddCategoryRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var category = _mapper.Map<Category>(request);
                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveChangeAsync();
                return response.SetOk("Add Success !");
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(ex.Message);
            }
        }
        public async Task<ApiResponse> GetCategoryByIdAsync(int id)
        {   
            try
            {
                ApiResponse response = new ApiResponse();
                var category = await _unitOfWork.Categories.GetAsync(s => s.Id == id);
                if (category == null)
                {
                    return response.SetNotFound($"Category Id: {id} not found");
                }
                var categoriesResponse = _mapper.Map<CategoryResponse>(category);
                return new ApiResponse().SetOk(categoriesResponse);
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest($"{ex.Message}");
            }
        }
        public async Task<ApiResponse> GetAllCategoryAsync()
        {
            try
            {
                var categories = await _unitOfWork.Categories.GetAllAsync(null);
                var categoriesResponse = _mapper.Map<List<CategoryResponse>>(categories);
                return new ApiResponse().SetOk(categoriesResponse);
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest($"{ex.Message}");
            }
        }
        public async Task<ApiResponse> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            ApiResponse response = new ApiResponse();
            var category = await _unitOfWork.Categories.GetAsync(s => s.Id == request.Id);
            if (category == null)
            {
                return response.SetNotFound($"Category Id: {request.Id} not found");
            }
            _mapper.Map(request, category);
            await _unitOfWork.SaveChangeAsync();

            return response.SetOk("Updated successfully");
        }
        public async Task<ApiResponse> RemoveCategoryAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetAsync(x => x.Id == id);

                if (category == null)
                {
                    return new ApiResponse().SetBadRequest("Can not find category !");
                }

                await _unitOfWork.Categories.RemoveByIdAsync(category.Id);

                await _unitOfWork.SaveChangeAsync();
                return new ApiResponse().SetOk("Success !");
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest(ex.Message);
            }
        }
    }
}
