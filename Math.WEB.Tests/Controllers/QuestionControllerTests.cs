using Math.BLL.Abstract.Services;
using Math.WEB.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Models.TopicModel;
using Moq;
using NUnit.Framework;

namespace Math.WEB.Tests.Controllers;

[TestFixture]
public class QuestionControllerTests
{
    private QuestionController _questionController;
    private Mock<IConfiguration> _mockConfiguration;
    private Mock<IQuestionService> _mockQuestionService;
    private Mock<ITopicService> _mockTopicService;
    private Mock<IAnswerService> _mockAnswerService;

    [SetUp]
    public void SetUp()
    {
        _mockConfiguration = new Mock<IConfiguration>();
        _mockQuestionService = new Mock<IQuestionService>();
        _mockTopicService = new Mock<ITopicService>();
        _mockAnswerService = new Mock<IAnswerService>();

        _questionController = new QuestionController(
            _mockConfiguration.Object,
            _mockQuestionService.Object,
            _mockTopicService.Object,
            _mockAnswerService.Object);
    }

    [Test]
    public async Task GetQuestionsByWord_Should_Return_Questions_By_Topic()
    {
        // Arrange
        TopicModel topic = new TopicModel() { Text = "random" };
        var questions = new List<QuestionModel>
        {
            new QuestionModel { Id = 1, TopicModel = topic },
            new QuestionModel { Id = 2, TopicModel = topic }
        };

        _mockQuestionService.Setup(service => service.Get10RandomQuestions())
            .ReturnsAsync(questions);

        // Act
        var result = await _questionController.GetQuestionsByWord(topic.Text);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okObjectResult = (OkObjectResult)result.Result;
        Assert.AreEqual(questions, okObjectResult.Value);
    }

    [Test]
    public async Task GetQuestionsByWord_Should_Return_NotFound_If_No_Questions_Found()
    {
        // Arrange
        var topic = "nonexistent-topic";
        ICollection<QuestionModel> questions = null;

        _mockQuestionService.Setup(service => service.GetQuestionsByTopic(topic))
            .ReturnsAsync(questions);

        // Act
        var result = await _questionController.GetQuestionsByWord(topic);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

    [Test]
    public async Task GetById_Should_Return_Question_By_Id()
    {
        // Arrange
        var id = 1;
        var question = new QuestionModel { Id = id };

        _mockQuestionService.Setup(service => service.GetByIdAsync(id))
            .ReturnsAsync(question);

        // Act
        var result = await _questionController.GetById(id);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okObjectResult = (OkObjectResult)result.Result;
        Assert.AreEqual(question, okObjectResult.Value);
    }

    [Test]
    public async Task GetById_Should_Return_NotFound_If_Question_Not_Found()
    {
        // Arrange
        var id = 1;
        QuestionModel question = null;

        _mockQuestionService.Setup(service => service.GetByIdAsync(id))
            .ReturnsAsync(question);

        // Act
        var result = await _questionController.GetById(id);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

    [Test]
    public async Task Create_Should_Create_New_Question()
    {
        // Arrange
        var model = new QuestionModel { Id = 1 };
        var createdQuestion = new QuestionModel { Id = 1 };

        _mockQuestionService.Setup(service => service.CreateAsync(model))
            .ReturnsAsync(createdQuestion);

        // Act
        var result = await _questionController.Create(model);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
        var createdAtActionResult = (CreatedAtActionResult)result.Result;
        Assert.AreEqual(nameof(QuestionController.GetById), createdAtActionResult.ActionName);
        Assert.AreEqual(createdQuestion, createdAtActionResult.Value);
    }

    [Test]
    public async Task Update_Should_Update_Existing_Question()
    {
        // Arrange
        var id = 1;
        var model = new QuestionModel { Id = id };
        var updated = true;

        _mockQuestionService.Setup(service => service.UpdateAsync(model))
            .ReturnsAsync(updated);

        // Act
        var result = await _questionController.Update(id, model);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public async Task Update_Should_Return_NotFound_If_Question_Not_Updated()
    {
        // Arrange
        var id = 1;
        var model = new QuestionModel { Id = id };
        var updated = false;

        _mockQuestionService.Setup(service => service.UpdateAsync(model))
            .ReturnsAsync(updated);

        // Act
        var result = await _questionController.Update(id, model);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public async Task Delete_Should_Delete_Question_By_Id()
    {
        // Arrange
        var id = 1;
        var deleted = true;

        _mockQuestionService.Setup(service => service.DeleteAsync(id))
            .ReturnsAsync(deleted);

        // Act
        var result = await _questionController.Delete(id);

        // Assert
        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public async Task Delete_Should_Return_NotFound_If_Question_Not_Deleted()
    {
        // Arrange
        var id = 1;
        var deleted = false;

        _mockQuestionService.Setup(service => service.DeleteAsync(id))
            .ReturnsAsync(deleted);

        // Act
        var result = await _questionController.Delete(id);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    // Add more test methods as needed

    [TearDown]
    public void TearDown()
    {
        _questionController = null;
        _mockConfiguration = null;
        _mockQuestionService = null;
        _mockTopicService = null;
        _mockAnswerService = null;
    }
}
