using Application.Interface;
using Application.Request.Category;
using Application.Request.Product;
using Application.Response;
using AutoMapper;
using Domain;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddProductAsync(CreateProductRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var category = await _unitOfWork.Categories.GetAsync(s => s.Id == request.CategoryId);
                if (category == null)
                {
                    return response.SetNotFound($"Category Id: {request.CategoryId} not found");
                }
                var product = _mapper.Map<Product>(request);
                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangeAsync();
                return response.SetOk("Add Success !");
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(ex.Message);
            }
        }
    }
}
