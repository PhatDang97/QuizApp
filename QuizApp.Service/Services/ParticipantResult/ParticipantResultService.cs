﻿using AutoMapper;
using QuizApp.Common.Result;
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
