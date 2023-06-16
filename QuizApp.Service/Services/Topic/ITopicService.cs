using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface ITopicService
    {
        Task<ApiResult<IList<TopicDto>>> GetAll();
        Task<ApiResult<IList<TopicDto>>> GetAllIncludeGroup();
        Task<ApiResult<TopicDto>> Create(TopicCreateDto dto);
        Task<ApiResult<bool>> DeleteById(Guid id);
    }
}
