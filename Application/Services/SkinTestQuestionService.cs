using Application.Interface;
using Application.Request.SkinTestQuestion;
using Application.Response;
using Application.Response.Product;
using Application.Response.SkinTestQuestion;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkinTestQuestionService : ISkinTestQuestionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IClaimService _claim;
        public SkinTestQuestionService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claim)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _claim = claim;
        }
        public async Task<ApiResponse> CreateQuestion(CreateQuizQuestionRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            var question = _mapper.Map<SkinTestQuestion>(request);
            await _unitOfWork.SkinTestQuestions.AddAsync(question);
            await _unitOfWork.SaveChangeAsync();

            var answers = _mapper.Map<List<SkinTestAnswer>>(request.Answers);
            foreach (var answerEntity in answers)
            {
                answerEntity.SkinTestQuestionId = question.Id;
                await _unitOfWork.SkinTestAnswers.AddAsync(answerEntity);
            }

            await _unitOfWork.SaveChangeAsync();

            return apiResponse.SetOk("Create Success");
        }
        public async Task<ApiResponse> GetAllQuestions()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var skinTestQuestions = await _unitOfWork.SkinTestQuestions.GetAllAsync(null, x => x.Include(x => x.SkinTestAnswers));
                var responseList = _mapper.Map<List<QuizQuestionResponse>>(skinTestQuestions);
                return response.SetOk(responseList);
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(ex.Message);
            }
        }
    }
}
