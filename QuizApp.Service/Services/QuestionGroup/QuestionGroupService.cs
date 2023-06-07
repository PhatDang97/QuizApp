using AutoMapper;
using QuizApp.Common.Paging;
using QuizApp.Common.Result;
using QuizApp.Core.Entities;
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

        public async Task<ApiResult<bool>> Create(QuestionGroupCreateDto dto)
        {
            try
            {
                var questionGroupOld = await _unitOfWork.QuestionGroupRepository.GetByName(dto.Name);
                if (questionGroupOld != null)
                {
                    return new ApiErrorResult<bool>($"QuesionGroup [{dto.Name}] is existing!");
                }
                var entity = _mapper.Map<QuestionGroup>(dto);
                await _unitOfWork.QuestionGroupRepository.Add(entity);
                var result = await _unitOfWork.SaveChangesAsync();
                if (result == true)
                {
                    return new ApiSuccessResult<bool>($"Create a QuesionGroup [{dto.Name}] successfully!");
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>($"Error: {ex.Message}");
            }
            return new ApiErrorResult<bool>($"Create a QuesionGroup [{dto.Name}] failed!");
        }

        public async Task<ApiResult<bool>> DeleteById(Guid id)
        {
            var questionGroup = await _unitOfWork.QuestionGroupRepository.GetById(id);
            try
            {
                if (questionGroup != null)
                {
                    _unitOfWork.QuestionGroupRepository.Delete(questionGroup);
                    var result = await _unitOfWork.SaveChangesAsync();
                    if (result == true)
                    {
                        return new ApiSuccessResult<bool>($"Delete QuesionGroup [{questionGroup.Name}] successfully!");
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
            return new ApiErrorResult<bool>($"Delete QuesionGroup [{questionGroup.Name}] failed!");
        }
    }
}
