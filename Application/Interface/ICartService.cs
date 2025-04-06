using Application.Request.Cart;
using Application.Request.CartItem;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICartService
    {
        Task<ApiResponse> AddToCartAsync(AddToCartRequest request);
        Task<ApiResponse> GetCartAsync();
        Task<ApiResponse> RemoveCartItemAsync(int productId);
        Task<ApiResponse> UpdateCartItemAsync(UpdateCartItemRequest request);
    }
}
