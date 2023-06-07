using AutoMapper;
using QuizApp.Common.Result;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<IList<QuestionDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.QuestionRepository.GetAll();
                var questionList = _mapper.Map<IList<QuestionDto>>(result);

                return new ApiSuccessResult<IList<QuestionDto>>(questionList);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<IList<QuestionDto>>("Get Question failed:" + ex.Message);
            }
        }

        public async Task<ApiResult<bool>> Create(QuestionCreateDto dto)
        {
            try
            {
                //var topicOld = await _unitOfWork.TopicRepository.GetByName(dto.Name);
                //if (topicOld != null)
                //{
                //    return new ApiErrorResult<bool>($"Topic [{dto.Name}] is existing!");
                //}
                var entity = _mapper.Map<Question>(dto);
                await _unitOfWork.QuestionRepository.Add(entity);
                var result = await _unitOfWork.SaveChangesAsync();
                if (result == true)
                {
                    return new ApiSuccessResult<bool>($"Create a Question [{dto.Name}] successfully!");
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>($"Error: {ex.Message}");
            }
            return new ApiErrorResult<bool>($"Create a Question [{dto.Name}] failed!");
        }

        public async Task<ApiResult<bool>> DeleteById(Guid id)
        {
            var topic = await _unitOfWork.QuestionRepository.GetById(id);
            try
            {
                if (topic != null)
                {
                    _unitOfWork.QuestionRepository.Delete(topic);
                    var result = await _unitOfWork.SaveChangesAsync();
                    if (result == true)
                    {
                        return new ApiSuccessResult<bool>($"Delete Question [{topic.Name}] successfully!");
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
            return new ApiErrorResult<bool>($"Delete Question [{topic.Name}] failed!");
        }

        //public async Task<ApiResult<bool>> GetAnswers(int[] ids)
        //{
        //    var result = _context.Questions
        //        .AsEnumerable()
        //        .Where(x => ids.Contains(x.Id))
        //        .OrderBy(x => { return Array.IndexOf(ids, x.Id); })
        //        .Select(x => x.Answer)
        //        .ToList();
        //}
    }
}
