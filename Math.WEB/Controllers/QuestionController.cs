using Math.BLL.Abstract.Services;
using Microsoft.AspNetCore.Mvc;
// using System.Text.Json;
using Models;

namespace Math.WEB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IQuestionService _questionService;
    private readonly ITopicService _topicService;
    private readonly IAnswerService _answerService;


    public QuestionController(IConfiguration configuration,
        IQuestionService questionService, ITopicService topicService, IAnswerService answerService)
    {
        _configuration = configuration;
        _questionService = questionService;
        _topicService = topicService;
        _answerService = answerService;
    }

    // [HttpGet("Random")]
    // public async Task<ActionResult<ICollection<QuestionModel>>> Get10RandomQuestions()
    // {
    //     try
    //     {
    //         ICollection<QuestionModel> randomQuestions = await _questionService.Get10RandomQuestions();
    //         return Ok(randomQuestions);
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, ex.Message);
    //     }
    // }

    [HttpGet("{topic}")]
    public async Task<ActionResult<ICollection<QuestionModel>>> GetQuestionsByWord(string topic)
    {
        try
        {
            ICollection<QuestionModel> questions;
 
            if (topic == "random")
            {
                questions = await _questionService.Get10RandomQuestions();
            }
            else
            {
                questions = await _questionService.GetQuestionsByTopic(topic);
            }

            if (questions == null || questions.Count == 0)
            {
                return NotFound(); // Return 404 Not Found if no questions are found for the word
            }

            return Ok(questions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


  

    [HttpGet("{id:int}")]
    public async Task<ActionResult<QuestionModel>> GetById(int id)
    {
        try
        {
            var question = await _questionService.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<QuestionModel>> Create(QuestionModel model)
    {
        try
        {
            var createdQuestion = await _questionService.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = createdQuestion.Id }, createdQuestion);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, QuestionModel model)
    {
        try
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var updated = await _questionService.UpdateAsync(model);
            if (updated)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var deleted = await _questionService.DeleteAsync(id);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
