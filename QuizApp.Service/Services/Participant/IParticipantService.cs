using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface IParticipantService
    {
        Task<ApiResult<IList<ParticipantDto>>> GetAll();
        Task<ApiResult<bool>> Create(ParticipantCreateDto dto);
        Task<ApiResult<bool>> DeleteById(Guid id);
    }
}
