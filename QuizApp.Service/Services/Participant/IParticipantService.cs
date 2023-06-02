using QuizApp.Common.Result;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Services
{
    public interface IParticipantService
    {
        Task<ApiResult<IList<ParticipantDto>>> GetAll();
    }
}
