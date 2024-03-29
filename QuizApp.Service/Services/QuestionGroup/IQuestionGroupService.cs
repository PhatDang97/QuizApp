﻿using QuizApp.Common.Paging;
using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface IQuestionGroupService
    {
        Task<ApiResult<PagedResult<QuestionGroupDto>>> GetQuestionGroupsPaging(GetQuestionGroupPagingRequest request);
        Task<ApiResult<IList<QuestionGroupDto>>> GetAll();
        Task<ApiResult<QuestionGroupDto>> Create(QuestionGroupCreateDto dto);
        Task<ApiResult<bool>> DeleteById(Guid id);
        Task<ApiResult<QuestionGroupDto>> GetById(Guid id);
        Task<ApiResult<QuestionGroupDto>> GetIncludeQuestionById(Guid id);
    }
}
