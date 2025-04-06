using Application.Interface;
using Application.Request.Cart;
using Application.Request.CartItem;
using Application.Request.Product;
using Application.Response;
using Application.Response.Cart;
using Application.Response.Category;
using Application.Response.Product;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CartService: ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IClaimService _claimService;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimService = claimService;
        }
        public async Task<ApiResponse> AddToCartAsync( AddToCartRequest request)
        {
            var response = new ApiResponse();

            // Lấy user cùng với Cart và CartItems
            var claim = _claimService.GetUserClaim();
            var user = await _unitOfWork.UserAccounts.GetAsync(x => x.Id == claim.Id,x=>x.Include(x=>x.Cart)
                                                                                           .ThenInclude(x=>x.CartItems));
            
            if (user == null)
                return response.SetBadRequest("User not found");
            if (user.Cart == null)
            {
                user.Cart = new Cart
                {
                    UserId = user.Id,
                    CartItems = new List<CartItem>()
                };
                await _unitOfWork.Carts.AddAsync(user.Cart);
                await _unitOfWork.SaveChangeAsync();
            }
            var existingItem = await _unitOfWork.CartItems.GetAsync(x => x.ProductId == request.ProductId && x.CartId == user.Cart.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = user.Cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };
                await _unitOfWork.CartItems.AddAsync(cartItem);
            }
            await _unitOfWork.SaveChangeAsync();
            return response.SetOk("Product added to cart");
        }
        public async Task<ApiResponse> GetCartAsync()
        {
            try
            {
                var claim = _claimService.GetUserClaim();
                var user = await _unitOfWork.UserAccounts.GetAsync(x => x.Id == claim.Id, x => x.Include(x => x.Cart)
                                                                                               .ThenInclude(x => x.CartItems));
                var cart = await _unitOfWork.Carts.GetAsync(x => x.Id == user.Cart.Id, x => x.Include(x => x.CartItems).ThenInclude(x => x.Product));

                var responseList = _mapper.Map<CartResponse>(cart);
                return new ApiResponse().SetOk(responseList);
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest($"{ex.Message}");
            }
        }
        public async Task<ApiResponse> UpdateCartItemAsync(UpdateCartItemRequest request)
        {
            try
            {
                var response = new ApiResponse();
                var claim = _claimService.GetUserClaim();
                var user = await _unitOfWork.UserAccounts.GetAsync(x => x.Id == claim.Id, x => x.Include(x => x.Cart)
                                                                                               .ThenInclude(x => x.CartItems));

                if (user == null || user.Cart == null)
                    return response.SetBadRequest("Cart not found");

                var cartItem = await _unitOfWork.CartItems.GetAsync(ci => ci.ProductId == request.ProductId);
                if (cartItem == null)
                    return response.SetBadRequest("Product not found in cart");
                if (request.Quantity <= 0)
                    return response.SetBadRequest("Quantity must be greater than zero");
                cartItem.Quantity = request.Quantity;
                await _unitOfWork.SaveChangeAsync();

                return response.SetOk("Cart item updated successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest($"{ex.Message}");
            }

        }


        public async Task<ApiResponse> RemoveCartItemAsync(int productId)
        {
            try
            {
                var response = new ApiResponse();
                var claim = _claimService.GetUserClaim();
                var user = await _unitOfWork.UserAccounts.GetAsync(x => x.Id == claim.Id, x => x.Include(x => x.Cart)
                                                                                               .ThenInclude(x => x.CartItems));

                if (user == null || user.Cart == null)
                    return response.SetBadRequest("Cart not found");

                var cartItem = await _unitOfWork.CartItems.GetAsync(x => x.ProductId == productId);
                if (cartItem == null)
                    return response.SetBadRequest("Product not found in cart");
                await _unitOfWork.CartItems.RemoveByIdAsync(cartItem.Id);
                await _unitOfWork.SaveChangeAsync();

                return response.SetOk("Cart item removed successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse().SetBadRequest($"{ex.Message}");
            }

        }

    }
}
