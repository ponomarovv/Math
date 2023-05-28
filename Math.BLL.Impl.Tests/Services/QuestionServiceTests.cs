using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Math.BLL.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;
using Moq;
using NUnit.Framework;

namespace Math.BLL.Tests.Services
{
    [TestFixture]
    public class QuestionServiceTests
    {
        private QuestionService _questionService;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _questionService = new QuestionService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Get10RandomQuestions_Should_Return_2_Questions()
        {
            // Arrange
            var allQuestions = new List<QuestionModel>
            {
                new QuestionModel { Id = 1 },
                new QuestionModel { Id = 2 },
                // Add more sample questions as needed
            };

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.GetAllAsync(It.IsAny<Func<Entities.Question, bool>>()))
                .ReturnsAsync(allQuestions.Select(q => _mockMapper.Object.Map<Entities.Question>(q)).ToList());


            // Act
            var result = await _questionService.Get10RandomQuestions();

            // Assert
            Assert.AreEqual(2, result.Count);
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
                // Add more sample questions with the specified topic
            };

            _mockUnitOfWork.Setup(uow => uow.QuestionRepository.GetAllAsync(It.IsAny<Func<Entities.Question, bool>>()))
                .ReturnsAsync(allQuestions.Select(q => _mockMapper.Object.Map<Entities.Question>(q)).ToList());


            // Act
            var result = await _questionService.GetQuestionsByTopic(topic);

            // Assert
            Assert.AreEqual(expected, result.Count);
        }

        // Add more test methods as needed

        [TearDown]
        public void TearDown()
        {
            _questionService = null;
            _mockUnitOfWork = null;
            _mockMapper = null;
        }
    }
}
