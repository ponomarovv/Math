using Math.BLL.Abstract.Services;
using Microsoft.AspNetCore.Mvc;
using Models.TopicModel;

namespace Math.WEB.Controllers
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
        public async Task<ActionResult<List<TopicModel>>> GetAllTopics()
        {
            var topics = await _topicService.GetAllAsync();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicModel>> GetTopicById(int id)
        {
            var topic = await _topicService.GetByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpPost]
        public async Task<ActionResult<TopicModel>> CreateTopic(TopicModel model)
        {
            var createdTopic = await _topicService.CreateAsync(model);
            return CreatedAtAction(nameof(GetTopicById), new { id = createdTopic.Id }, createdTopic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, TopicModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var result = await _topicService.UpdateAsync(model);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var result = await _topicService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
