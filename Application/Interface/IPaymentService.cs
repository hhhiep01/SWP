using Application.Request.Payment;
using Application.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPaymentService
    {
        Task<ApiResponse> ProcessCashPayment(PaymentRequest paymentRequest);
        Task<ApiResponse> ProcessPaymentAsync(PaymentRequest paymentRequest, HttpContext context);
    }
}
