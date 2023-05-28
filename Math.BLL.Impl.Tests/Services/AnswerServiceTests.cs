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
    public class AnswerServiceTests
    {
        private IAnswerService _answerService;
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

            _answerService = new AnswerService(_mockUnitOfWork.Object, _mapper);
        }

        [Test]
        public async Task CreateAsync_Should_Add_New_Answer()
        {
            // Arrange
            var model = new AnswerModel { Text = "Test Answer" };
            var entity = _mapper.Map<Answer>(model);
            var addedEntity = _mapper.Map<AnswerModel>(entity);

            _mockUnitOfWork.Setup(uow => uow.AnswerRepository.AddAsync(It.IsAny<Answer>()))
                .ReturnsAsync(entity);
            // _mockUnitOfWork.Setup(uow => uow.SaveChangesAsync())
            //     .ReturnsAsync<AnswerModel>(1);

            // Act
            var result = await _answerService.CreateAsync(model);

            // Assert
            Assert.AreEqual(addedEntity.Text, result.Text);
            _mockUnitOfWork.Verify(uow => uow.AnswerRepository.AddAsync(It.IsAny<Answer>()), Times.Once);
            // _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            
            
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Answers()
        {
            // Arrange
            var entities = new List<Answer>
            {
                new Answer { Id = 1, Text = "Answer 1" },
                new Answer { Id = 2, Text = "Answer 2" },
                // Add more sample answers as needed
            };
            var expected = entities.Select(a => _mapper.Map<AnswerModel>(a)).ToList();

            _mockUnitOfWork.Setup(uow => uow.AnswerRepository.GetAllAsync(It.IsAny<Func<Answer, bool>>()))
                .ReturnsAsync(entities);

            // Act
            var result = await _answerService.GetAllAsync();

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
            CollectionAssert.AreEqual(expected.Select(a => a.Text), result.Select(a => a.Text));
            _mockUnitOfWork.Verify(uow => uow.AnswerRepository.GetAllAsync(It.IsAny<Func<Answer, bool>>()), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Answer_By_Id()
        {
            // Arrange
            var id = 1;
            var entity = new Answer { Id = id, Text = "Test Answer" };
            var expected = _mapper.Map<AnswerModel>(entity);

            _mockUnitOfWork.Setup(uow => uow.AnswerRepository.GetByIdAsync(id))
                .ReturnsAsync(entity);

            // Act
            var result = await _answerService.GetByIdAsync(id);

            // Assert
            Assert.AreEqual(expected.Text, result.Text);
            _mockUnitOfWork.Verify(uow => uow.AnswerRepository.GetByIdAsync(id), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Existing_Answer()
        {
            // Arrange
            var model = new AnswerModel { Id = 1, Text = "Updated Answer" };
            var entity = _mapper.Map<Answer>(model);

            _mockUnitOfWork.Setup(uow => uow.AnswerRepository.UpdateAsync(It.IsAny<Answer>()))
                .ReturnsAsync(true);
            // _mockUnitOfWork.Setup(uow => uow.SaveChangesAsync())
            //     .Returns(0);

            // Act
            var result = await _answerService.UpdateAsync(model);

            // Assert
            Assert.IsTrue(result);
            _mockUnitOfWork.Verify(uow => uow.AnswerRepository.UpdateAsync(It.IsAny<Answer>()), Times.Once);
            // _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_Should_Remove_Existing_Answer()
        {
            // Arrange
            var id = 1;

            _mockUnitOfWork.Setup(uow => uow.AnswerRepository.DeleteAsync(id))
                .ReturnsAsync(true);
            // _mockUnitOfWork.Setup(uow => uow.SaveChangesAsync())
            //     .ReturnsAsync(1);

            // Act
            var result = await _answerService.DeleteAsync(id);

            // Assert
            Assert.IsTrue(result);
            _mockUnitOfWork.Verify(uow => uow.AnswerRepository.DeleteAsync(id), Times.Once);
            // _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            _answerService = null;
            _mockUnitOfWork = null;
            _mapper = null;
        }
    }
}
