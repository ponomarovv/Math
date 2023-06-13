using Math.BLL.Abstract.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Math.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]
        public async Task<ActionResult<QuizModel>> Create(QuizModel model)
        {
            var createdQuiz = await _quizService.CreateAsync(model);
            return Ok(createdQuiz);
        }

        [HttpGet]
        public async Task<ActionResult<List<QuizModel>>> GetAll()
        {
            var quizzes = await _quizService.GetAllAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizModel>> GetById(int id)
        {
            var quiz = await _quizService.GetByIdAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuizModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var updated = await _quizService.UpdateAsync(model);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _quizService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
