using Microsoft.AspNetCore.Mvc;
using QuizApp.Common.Paging;
using QuizApp.Service.Services;

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
    }
}
