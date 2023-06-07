using Microsoft.AspNetCore.Mvc;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _topicService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllIncludeQuestionGroup")]
        public async Task<IActionResult> GetAllIncludeQuestionGroup()
        {
            var result = await _topicService.GetAllIncludeGroup();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(TopicCreateDto topic)
        {
            var result = await _topicService.Create(topic);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _topicService.DeleteById(id);
            return Ok(result);
        }
    }
}
