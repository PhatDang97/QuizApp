using AutoMapper;
using QuizApp.Common.Result;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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

        public async Task<ApiResult<IList<TopicDto>>> GetAllIncludeGroup()
        {
            try
            {
                var result = await _unitOfWork.TopicRepository.GetAllIncludeGroup();
                var topicList = _mapper.Map<IList<TopicDto>>(result);

                return new ApiSuccessResult<IList<TopicDto>>(topicList);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<IList<TopicDto>>("Get Topic failed:" + ex.Message);
            }
        }

        public async Task<ApiResult<TopicDto>> Create(TopicCreateDto dto)
        {
            try
            {
                var topicOld = await _unitOfWork.TopicRepository.GetByName(dto.Name);
                if (topicOld != null)
                {
                    return new ApiErrorResult<TopicDto>($"Topic [{dto.Name}] is existing!");
                }
                var entity = _mapper.Map<Topic>(dto);
                await _unitOfWork.TopicRepository.Add(entity);
                var result = await _unitOfWork.SaveChangesAsync();
                if (result == true)
                {
                    var data = _mapper.Map<TopicDto>(entity);
                    return new ApiSuccessResult<TopicDto>(data);
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<TopicDto>($"Error: {ex.Message}");
            }
            return new ApiErrorResult<TopicDto>($"Create a Topic [{dto.Name}] failed!");
        }

        public async Task<ApiResult<bool>> DeleteById(Guid id)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(id);
            try
            {
                if (topic != null)
                {
                    _unitOfWork.TopicRepository.Delete(topic);
                    var result = await _unitOfWork.SaveChangesAsync();
                    if (result == true)
                    {
                        return new ApiSuccessResult<bool>($"Delete Topic [{topic.Name}] successfully!");
                    }
                }
                else
                {
                    return new ApiErrorResult<bool>($"Cannot found");
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
            return new ApiErrorResult<bool>($"Delete Topic [{topic.Name}] failed!");
        }
    }
}
