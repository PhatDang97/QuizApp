using AutoMapper;
using QuizApp.Common.Result;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public async Task<ApiResult<IList<TopicDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.TopicRepository.GetAll();
                var topicList = _mapper.Map<IList<TopicDto>>(result);

                return new ApiSuccessResult<IList<TopicDto>>(topicList);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<IList<TopicDto>>("Get Topic failed:" + ex.Message);
            }
        }
    }
}
