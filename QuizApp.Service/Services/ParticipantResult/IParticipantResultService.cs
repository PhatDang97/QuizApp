using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface IParticipantResultService
    {
        Task<ApiResult<IList<ParticipantResultDto>>> GetAll();
    }
}
