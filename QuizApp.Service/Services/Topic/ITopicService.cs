﻿using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface ITopicService
    {
        Task<ApiResult<IList<TopicDto>>> GetAll();
    }
}
