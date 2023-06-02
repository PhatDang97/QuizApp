﻿using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface IQuestionService
    {
        Task<ApiResult<IList<QuestionDto>>> GetAll();
    }
}
