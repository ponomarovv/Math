using Math.BLL.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// using System.Text.Json;
using System.Text.Json.Serialization;
using Models;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Math.WEB.Controllers
{
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
        [HttpGet]
        [Route("GetQuestion")]
        public async Task<IActionResult> GetQuestion()
        {
            using var client = new HttpClient();

            QuestionModel question = _questionService.GetByIdAsync(1).Result;

            // Serialize the object using JsonConvert with the PreserveReferencesHandling setting
            var serializedQuestion = JsonConvert.SerializeObject(question, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            // Serialize the object using JsonSerializer with the specified JsonSerializerOptions
            var parsedJson = JToken.Parse(serializedQuestion);

            // Format the parsed JSON with indented formatting
            var prettierJson = parsedJson.ToString(Formatting.Indented);

            return Ok(prettierJson);

            return Ok(serializedQuestion);


            return Ok(question);
        }

    }
}
