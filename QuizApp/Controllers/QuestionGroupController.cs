using Microsoft.AspNetCore.Mvc;
using QuizApp.Common.Paging;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionGroupController : ControllerBase
    {
        private readonly IQuestionGroupService _questionGroupService;
        public QuestionGroupController(IQuestionGroupService questionGroupService)
        {
            _questionGroupService = questionGroupService;
        }

        [HttpPost]
        [Route("GetAllPaging")]
        public async Task<IActionResult> GetAllPaging(GetQuestionGroupPagingRequest request)
        {
            var result = await _questionGroupService.GetQuestionGroupsPaging(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionGroupService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(QuestionGroupCreateDto topic)
        {
            var result = await _questionGroupService.Create(topic);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _questionGroupService.DeleteById(id);
            return Ok(result);
        }
    }
}
