using Math.BLL.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Math.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IQuestionService _questionService;

        public QuestionController(IConfiguration configuration, IQuestionService questionService)
        {
            _configuration = configuration;
            _questionService = questionService;
        }
        [HttpGet]
        [Route("GetQuestion")]
        public async Task<IActionResult> GetQuestion()
        {
            using var client = new HttpClient();

            var question = _questionService.GetByIdAsync(1).Result;

            // Create JsonSerializerOptions with ReferenceHandler set to ReferenceHandler.Preserve
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            // Serialize the object using JsonSerializer with the specified JsonSerializerOptions
            var serializedQuestion = JsonSerializer.Serialize(question, jsonSerializerOptions);

            return Ok(serializedQuestion);


            return Ok(question);
        }

    }
}
