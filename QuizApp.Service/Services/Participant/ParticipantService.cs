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

        public async Task<ApiResult<ParticipantDto>> Create(ParticipantCreateDto dto)
        {
            try
            {
                var participantOld = await _unitOfWork.ParticipantRepository.GetParticipant(dto.Email, dto.UserName);
                if (participantOld != null)
                {
                    var dataResult = _mapper.Map<ParticipantDto>(participantOld);
                    return new ApiSuccessResult<ParticipantDto>(dataResult);
                }
                var entity = _mapper.Map<Participant>(dto);
                await _unitOfWork.ParticipantRepository.Add(entity);
                var result = await _unitOfWork.SaveChangesAsync();
                var data = _mapper.Map<ParticipantDto>(entity);
                if (result == true)
                {
                    return new ApiSuccessResult<ParticipantDto>(data);
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<ParticipantDto>($"Error: {ex.Message}");
            }
            return new ApiErrorResult<ParticipantDto>($"Create a Participant [{dto.Email}] failed!");
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
