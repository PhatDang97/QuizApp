using AutoMapper;
using QuizApp.Common.Result;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParticipantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult<IList<ParticipantDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.ParticipantRepository.GetAll();
                var participantList = _mapper.Map<IList<ParticipantDto>>(result);

                return new ApiSuccessResult<IList<ParticipantDto>>(participantList);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<IList<ParticipantDto>>("Get Participant failed:" + ex.Message);
            }
        }
    }
}
