using AutoMapper;
using QuizApp.Common.Paging;
using QuizApp.Common.Result;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public class QuestionGroupService : IQuestionGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<IList<QuestionGroupDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.QuestionGroupRepository.GetAll();
                var questionGroupList = _mapper.Map<IList<QuestionGroupDto>>(result);

                return new ApiSuccessResult<IList<QuestionGroupDto>>(questionGroupList);
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<IList<QuestionGroupDto>>("Get Question Group failed:" + ex.Message);
            }
        }

        public async Task<ApiResult<PagedResult<QuestionGroupDto>>> GetQuestionGroupsPaging(GetQuestionGroupPagingRequest request)
        {
            try
            {
                var result = await _unitOfWork.QuestionGroupRepository.GetQuestionGroupsPaging(request);
                var pagedQuestionGroup = _mapper.Map<PagedResult<QuestionGroupDto>>(result);
                return new ApiSuccessResult<PagedResult<QuestionGroupDto>>(pagedQuestionGroup);
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<PagedResult<QuestionGroupDto>>("Get Question Group failed:" + ex.Message);
            }
        }
    }
}
