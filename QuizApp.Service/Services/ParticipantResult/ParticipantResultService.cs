using AutoMapper;
using QuizApp.Common.Result;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public class ParticipantResultService : IParticipantResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ParticipantResultService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<ParticipantResultDto>> Create(ParticipantResultCreateDto participantResult)
        {
            try
            {
                var entity = _mapper.Map<ParticipantResult>(participantResult);
                await _unitOfWork.ParticipantResultRepository.Add(entity);
                
                var resultData = new QuizResultsCreateDto()
                {
                    ParticipantId = participantResult.ParticipantId,
                    QuestionGroupId = participantResult.QuestionGroupId,
                    ParticipantResultId = entity.Id,
                };
                var resultEntity = _mapper.Map<QuizResults>(resultData);
                await _unitOfWork.ResultRepository.Add(resultEntity);

                var result = await _unitOfWork.SaveChangesAsync();
                if (result == true)
                {
                    var data = _mapper.Map<ParticipantResultDto>(entity);
                    return new ApiSuccessResult<ParticipantResultDto>(data);
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<ParticipantResultDto>($"Error: {ex.Message}");
            }
            return new ApiErrorResult<ParticipantResultDto>($"Create a ParticipantResult failed!");
        }

        public async Task<ApiResult<IList<ParticipantResultDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.ParticipantResultRepository.GetAll();
                var participantResultList = _mapper.Map<IList<ParticipantResultDto>>(result);

                return new ApiSuccessResult<IList<ParticipantResultDto>>(participantResultList);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<IList<ParticipantResultDto>>("Get ParticipantResult failed:" + ex.Message);
            }
        }
    }
}
