using Application.Interface;
using Application.Request.Payment;
using Application.Response;
using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService: IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IClaimService _claim;
        private readonly IVnPayService _vnPayService;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService, IVnPayService vnPayService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _claim = claimService;
            _vnPayService = vnPayService;  
        }
        public async Task<ApiResponse> ProcessPaymentAsync(PaymentRequest paymentRequest, HttpContext context)
        {
            var selectedPaymentMethod = paymentRequest.PaymentMethod;
            ApiResponse response = new ApiResponse();
            switch (selectedPaymentMethod)
            {
                case PaymentMethod.VnPay:
                    return await _vnPayService.CreatePaymentUrl(paymentRequest, context);
                case PaymentMethod.Cash:
                    return await ProcessCashPayment(paymentRequest);  
                default:
                    return response.SetBadRequest("Invalid payment method selected.");
            }
        }
        public async Task<ApiResponse> ProcessCashPayment(PaymentRequest paymentRequest)
        {
            ApiResponse response = new ApiResponse();
            var order = await _unitOfWork.Orders.GetAsync(o => o.Id == paymentRequest.OrderId);
            if (order == null)
            {
                return response.SetBadRequest("Order not found.");
            }

            // Cập nhật trạng thái đơn hàng thành "AwaitingPayment" hoặc tương tự
            order.StatusOrder = StatusOrder.AwaitingPayment;
            await _unitOfWork.SaveChangeAsync();

            // Lưu thông tin thanh toán vào bảng Payments với PaymentMethod = "Cash"
            var payment = new Payment
            {
                OrderId = paymentRequest.OrderId,
                AmountPaid = order.TotalPrice,
                PaymentMethod = PaymentMethod.Cash,  
                PaymentStatus = PaymentStatus.Pending,  
            };
            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveChangeAsync();
            return response.SetOk("Success");
        }    
    }
}
