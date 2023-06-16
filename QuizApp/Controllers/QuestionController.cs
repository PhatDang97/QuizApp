using Microsoft.AspNetCore.Mvc;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(QuestionCreateDto topic)
        {
            var result = await _questionService.Create(topic);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _questionService.DeleteById(id);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("GetQuestions")]
        //public async Task<IActionResult> GetQuestions()
        //{
        //    // QnId = ID, Qn = QuestionName
        //    var result = await _questionService.GetAll();
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("Answers")]
        //public IActionResult GetAnswers(int[] ids)
        //{
        //    var result = _context.Questions
        //        .AsEnumerable()
        //        .Where(x => ids.Contains(x.Id))
        //        .OrderBy(x => { return Array.IndexOf(ids, x.Id); })
        //        .Select(x => x.Answer)
        //        .ToList();

        //    return Ok(result);
        //}
    }
}
