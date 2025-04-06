using Application.Interface;
using Application.Response;
using Application.Response.Category;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IClaimService _claimService;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimService = claimService;
        }
        public async Task<ApiResponse> CreateOrderAsync()
        {
            try
            {   
                ApiResponse response = new ApiResponse();
                var claim = _claimService.GetUserClaim();
                var user = await _unitOfWork.UserAccounts.GetAsync(x => x.Id == claim.Id, x => x.Include(x => x.Cart)
                                                                                               .ThenInclude(x => x.CartItems));

                if (user == null)
                    return response.SetBadRequest("User not found");

                var cart = await _unitOfWork.Carts.GetAsync(x => x.UserId == user.Id,
                                                x => x.Include(x => x.CartItems)
                                                      .ThenInclude(x => x.Product));

                if (cart == null || !cart.CartItems.Any())
                    return new ApiResponse().SetBadRequest("empty cart");
                var total = cart.CartItems.Sum(item => item.Quantity * item.Product.Price);

                var order = new Order
                {
                    UserAccountId = user.Id,
                    TotalPrice = total,
                    StatusOrder = StatusOrder.Pending,
                    OrderDetails = cart.CartItems.Select(ci => new OrderDetail
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        Product = ci.Product 
                    }).ToList()
                };

                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveChangeAsync();

                // Xóa giỏ hàng
                cart.CartItems.Clear();
                await _unitOfWork.SaveChangeAsync();

                return new ApiResponse().SetOk("Đặt hàng thành công!");
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest($"{ex.Message}");
            }
            
        }
        public async Task<ApiResponse> GetAllOrderAsync()
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
    }
}
