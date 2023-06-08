using Microsoft.AspNetCore.Mvc;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _participantService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ParticipantCreateDto participant)
        {
            var result = await _participantService.Create(participant);
            return Ok(result);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _participantService.DeleteById(id);
            return Ok(result);
        }
    }
}
