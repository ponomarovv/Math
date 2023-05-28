using AutoMapper;
using Entities;
using Math.BLL.Abstract.Services;
using Math.BLL.Mappers;
using Math.BLL.Services;
using Math.DAL.Abstract.Repository.Base;
using Models;
using Moq;
using NUnit.Framework;

namespace Math.BLL.Impl.Tests.Services
{
    [TestFixture]
    public class QuizServiceTests
    {
        private IQuizService _quizService;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappersProfile());
            });
            _mapper = config.CreateMapper();

            _quizService = new QuizService(_mockUnitOfWork.Object, _mapper);
        }

        [Test]
        public async Task CreateAsync_Should_Create_New_Quiz()
        {
            // Arrange
            var model = new QuizModel { Id = 1, QuizDate = DateTime.Now };
            var newEntity = _mapper.Map<Quiz>(model);
            var expectedModel = _mapper.Map<QuizModel>(newEntity);

            _mockUnitOfWork.Setup(uow => uow.QuizRepository.AddAsync(It.IsAny<Quiz>()))
                .ReturnsAsync(newEntity);

            // Act
            var result = await _quizService.CreateAsync(model);

            // Assert
            Assert.AreEqual(expectedModel.Id, result.Id);
            Assert.AreEqual(expectedModel.QuizDate, result.QuizDate);
            _mockUnitOfWork.Verify(uow => uow.QuizRepository.AddAsync(It.IsAny<Quiz>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Quizzes()
        {
            // Arrange
            var allQuizzes = new List<Quiz>
            {
                new Quiz { Id = 1, QuizDate = DateTime.Now },
                new Quiz { Id = 2, QuizDate = DateTime.Now.AddDays(1) },
                // Add more sample quizzes as needed
            };

            _mockUnitOfWork.Setup(uow => uow.QuizRepository.GetAllAsync(It.IsAny<Func<Quiz, bool>>()))
                .ReturnsAsync(allQuizzes);

            // Act
            var result = await _quizService.GetAllAsync();

            // Assert
            Assert.AreEqual(allQuizzes.Count, result.Count);
            _mockUnitOfWork.Verify(uow => uow.QuizRepository.GetAllAsync(It.IsAny<Func<Quiz, bool>>()), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Quiz_By_Id()
        {
            // Arrange
            var id = 1;
            var quiz = new Quiz { Id = id, QuizDate = DateTime.Now };

            _mockUnitOfWork.Setup(uow => uow.QuizRepository.GetByIdAsync(id))
                .ReturnsAsync(quiz);

            // Act
            var result = await _quizService.GetByIdAsync(id);

            // Assert
            Assert.AreEqual(quiz.Id, result.Id);
            Assert.AreEqual(quiz.QuizDate, result.QuizDate);
            _mockUnitOfWork.Verify(uow => uow.QuizRepository.GetByIdAsync(id), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Existing_Quiz()
        {
            // Arrange
            var model = new QuizModel { Id = 1, QuizDate = DateTime.Now.AddDays(1) };
            var expectedUpdated = true;

            _mockUnitOfWork.Setup(uow => uow.QuizRepository.UpdateAsync(It.IsAny<Quiz>()))
                .ReturnsAsync(expectedUpdated);

            // Act
            var result = await _quizService.UpdateAsync(model);

            // Assert
            Assert.AreEqual(expectedUpdated, result);
            _mockUnitOfWork.Verify(uow => uow.QuizRepository.UpdateAsync(It.IsAny<Quiz>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_Should_Delete_Quiz_By_Id()
        {
            // Arrange
            var id = 1;
            var expectedDeleted = true;

            _mockUnitOfWork.Setup(uow => uow.QuizRepository.DeleteAsync(id))
                .ReturnsAsync(expectedDeleted);

            // Act
            var result = await _quizService.DeleteAsync(id);

            // Assert
            Assert.AreEqual(expectedDeleted, result);
            _mockUnitOfWork.Verify(uow => uow.QuizRepository.DeleteAsync(id), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        // Add more test methods as needed

        [TearDown]
        public void TearDown()
        {
            _quizService = null;
            _mockUnitOfWork = null;
            _mapper = null;
        }
    }
}
