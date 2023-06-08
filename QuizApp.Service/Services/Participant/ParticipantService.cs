using AutoMapper;
using QuizApp.Common.Result;
using QuizApp.Core.Entities;
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

        public async Task<ApiResult<bool>> Create(ParticipantCreateDto dto)
        {
            try
            {
                var participantOld = await _unitOfWork.ParticipantRepository.GetByEmail(dto.Email);
                if (participantOld != null)
                {
                    return new ApiErrorResult<bool>($"Participant [{dto.Email}] is existing!");
                }
                var entity = _mapper.Map<Participant>(dto);
                await _unitOfWork.ParticipantRepository.Add(entity);
                var result = await _unitOfWork.SaveChangesAsync();
                if (result == true)
                {
                    return new ApiSuccessResult<bool>($"Create a Participant [{dto.Email}] successfully!");
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>($"Error: {ex.Message}");
            }
            return new ApiErrorResult<bool>($"Create a Participant [{dto.Email}] failed!");
        }

        public async Task<ApiResult<bool>> DeleteById(Guid id)
        {
            var participant = await _unitOfWork.ParticipantRepository.GetById(id);
            try
            {
                if (participant != null)
                {
                    _unitOfWork.ParticipantRepository.Delete(participant);
                    var result = await _unitOfWork.SaveChangesAsync();
                    if (result == true)
                    {
                        return new ApiSuccessResult<bool>($"Delete Participant [{participant.Email}] successfully!");
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
            return new ApiErrorResult<bool>($"Delete Participant [{participant.Email}] failed!");
        }
    }
}
