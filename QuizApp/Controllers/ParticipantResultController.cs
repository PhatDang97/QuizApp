using Microsoft.AspNetCore.Mvc;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantResultController : ControllerBase
    {
        private readonly IParticipantResultService _participantResultService;

        public ParticipantResultController(IParticipantResultService participantResultService)
        {
            _participantResultService = participantResultService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _participantResultService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ParticipantResultCreateDto participantResult)
        {
            var result = await _participantResultService.Create(participantResult);
            return Ok(result);
        }
    }
}
