using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface IQuestionService
    {
        Task<ApiResult<IList<QuestionDto>>> GetAll();
        Task<ApiResult<QuestionDto>> Create(QuestionCreateDto dto);
        Task<ApiResult<bool>> DeleteById(Guid id);
    }
}
