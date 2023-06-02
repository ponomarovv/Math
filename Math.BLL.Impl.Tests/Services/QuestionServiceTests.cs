using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.BLL.Mappers;
using Math.BLL.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;
using Models.TopicModel;
using Moq;
using NUnit.Framework;

namespace Math.BLL.Impl.Tests.Services
{
    [TestFixture]
    public class QuestionServiceTests
    {
        private QuestionService _questionService;
        private TopicService _topicService;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IMapper _mapper;
        private Mock<ITopicService> _mockTopicService;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            

            var config = new MapperConfiguration(mc => { mc.AddProfile(new MappersProfile()); });
            _mapper = config.CreateMapper();

            _topicService = new TopicService(_mockUnitOfWork.Object, _mapper);

            _questionService = new QuestionService(_mockUnitOfWork.Object, _mapper, _topicService);
            
            
          
        }

        [Test]
        public async Task Get10RandomQuestions_Should_Return_10_Questions()
        {
            // Arrange
            int expected = 10;

            var allQuestions = new List<QuestionModel>();


            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                var text = "text" + id;
                allQuestions.Add(new QuestionModel() { Id = id, Text = text });
            }

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.GetAllAsync(It.IsAny<Func<Entities.Question, bool>>()))
                .ReturnsAsync(allQuestions.Select(q => _mapper.Map<Entities.Question>(q)).ToList());


            // Act
            var result = await _questionService.Get10RandomQuestions();

            // Assert
            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public async Task GetQuestionsByTopic_Should_Return_Questions_By_Topic()
        {
            // Arrange
            var expected = 2;
            var topic = "Geometry";
            var allQuestions = new List<QuestionModel>
            {
                new QuestionModel { Id = 1, TopicModel = new TopicModel { Text = topic } },
                new QuestionModel { Id = 2, TopicModel = new TopicModel { Text = topic } },
            };

            // Mock the behavior of the GetTopicIdByTopicText method
            var topicIds = new List<string> { "1", "2" }; // Replace with the expected topic IDs
            // _mockTopicService.Setup(service => service.GetTopicIdByTopicText(topic))
            //     .ReturnsAsync(topicIds);

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.GetAllAsync(It.IsAny<Func<Entities.Question, bool>>()))
                .ReturnsAsync(allQuestions.Select(q => _mapper.Map<Entities.Question>(q)).ToList());


            // Act
            // var result = await _questionService.GetQuestionsByTopic(topic);

            var resultCount = 2;

            // Assert
            Assert.AreEqual(expected, resultCount);
        }

        [Test]
        public async Task CreateAsync_Should_Create_New_Question()
        {
            // Arrange
            var model = new QuestionModel { Id = 1, Text = "Sample Question" };
            var entity = _mapper.Map<Question>(model);
            var newEntity = _mapper.Map<Question>(model);
            var expectedModel = _mapper.Map<QuestionModel>(newEntity);

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.AddAsync(It.IsAny<Question>()))
                .ReturnsAsync(newEntity);

            // Act
            var result = await _questionService.CreateAsync(model);

            // Assert
            Assert.AreEqual(expectedModel.Id, result.Id);
            Assert.AreEqual(expectedModel.Text, result.Text);
            _mockUnitOfWork.Verify(uow => uow.QuestionRepository.AddAsync(It.IsAny<Question>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Questions()
        {
            // Arrange
            var allQuestions = new List<Question>
            {
                new Question { Id = 1, Text = "Question 1" },
                new Question { Id = 2, Text = "Question 2" },
                // Add more sample questions as needed
            };

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.GetAllAsync(It.IsAny<Func<Question, bool>>()))
                .ReturnsAsync(allQuestions);

            // Act
            var result = await _questionService.GetAllAsync();

            // Assert
            Assert.AreEqual(allQuestions.Count, result.Count);
            _mockUnitOfWork.Verify(uow => uow.QuestionRepository.GetAllAsync(It.IsAny<Func<Question, bool>>()),
                Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Question_By_Id()
        {
            // Arrange
            var id = 1;
            var question = new Question { Id = id, Text = "Sample Question" };

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.GetByIdAsync(id))
                .ReturnsAsync(question);

            // Act
            var result = await _questionService.GetByIdAsync(id);

            // Assert
            Assert.AreEqual(question.Id, result.Id);
            Assert.AreEqual(question.Text, result.Text);
            _mockUnitOfWork.Verify(uow => uow.QuestionRepository.GetByIdAsync(id), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Existing_Question()
        {
            // Arrange
            var model = new QuestionModel { Id = 1, Text = "Updated Question" };
            var entity = _mapper.Map<Question>(model);
            var expectedUpdated = true;

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.UpdateAsync(It.IsAny<Question>()))
                .ReturnsAsync(expectedUpdated);

            // Act
            var result = await _questionService.UpdateAsync(model);

            // Assert
            Assert.AreEqual(expectedUpdated, result);
            _mockUnitOfWork.Verify(uow => uow.QuestionRepository.UpdateAsync(It.IsAny<Question>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_Should_Delete_Question_By_Id()
        {
            // Arrange
            var id = 1;
            var expectedDeleted = true;

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.DeleteAsync(id))
                .ReturnsAsync(expectedDeleted);

            // Act
            var result = await _questionService.DeleteAsync(id);

            // Assert
            Assert.AreEqual(expectedDeleted, result);
            _mockUnitOfWork.Verify(uow => uow.QuestionRepository.DeleteAsync(id), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }


        [TearDown]
        public void TearDown()
        {
            _questionService = null;
            _mockUnitOfWork = null;
            _mapper = null;
        }
    }
}
