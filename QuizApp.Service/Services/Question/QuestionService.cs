using AutoMapper;
using QuizApp.Common.Result;
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
    }
}
