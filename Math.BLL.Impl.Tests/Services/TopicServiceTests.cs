using AutoMapper;
using Entities;
using Entities.TopicEntity;
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
    public class TopicServiceTests
    {
        private ITopicService _topicService;
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

            _topicService = new TopicService(_mockUnitOfWork.Object, _mapper);
        }

        [Test]
        public async Task CreateAsync_Should_Create_New_Topic()
        {
            // Arrange
            var model = new TopicModel { Id = 1, Text = "Sample Topic" };
            var entity = _mapper.Map<Topic>(model);
            var newEntity = _mapper.Map<Topic>(model);
            var expectedModel = _mapper.Map<TopicModel>(newEntity);

            _mockUnitOfWork.Setup(uow => uow.TopicRepository.AddAsync(It.IsAny<Topic>()))
                .ReturnsAsync(newEntity);

            // Act
            var result = await _topicService.CreateAsync(model);

            // Assert
            Assert.AreEqual(expectedModel.Id, result.Id);
            Assert.AreEqual(expectedModel.Text, result.Text);
            _mockUnitOfWork.Verify(uow => uow.TopicRepository.AddAsync(It.IsAny<Topic>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Topics()
        {
            // Arrange
            var allTopics = new List<Topic>
            {
                new Topic { Id = 1, Text = "Topic 1" },
                new Topic { Id = 2, Text = "Topic 2" },
                // Add more sample topics as needed
            };

            _mockUnitOfWork.Setup(uow => uow.TopicRepository.GetAllAsync(It.IsAny<Func<Topic, bool>>()))
                .ReturnsAsync(allTopics);

            // Act
            var result = await _topicService.GetAllAsync();

            // Assert
            Assert.AreEqual(allTopics.Count, result.Count);
            _mockUnitOfWork.Verify(uow => uow.TopicRepository.GetAllAsync(It.IsAny<Func<Topic, bool>>()), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Topic_By_Id()
        {
            // Arrange
            var id = 1;
            var topic = new Topic { Id = id, Text = "Sample Topic" };

            _mockUnitOfWork.Setup(uow => uow.TopicRepository.GetByIdAsync(id))
                .ReturnsAsync(topic);

            // Act
            var result = await _topicService.GetByIdAsync(id);

            // Assert
            Assert.AreEqual(topic.Id, result.Id);
            Assert.AreEqual(topic.Text, result.Text);
            _mockUnitOfWork.Verify(uow => uow.TopicRepository.GetByIdAsync(id), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Existing_Topic()
        {
            // Arrange
            var model = new TopicModel { Id = 1, Text = "Updated Topic" };
            var entity = _mapper.Map<Topic>(model);
            var expectedUpdated = true;

            _mockUnitOfWork.Setup(uow => uow.TopicRepository.UpdateAsync(It.IsAny<Topic>()))
                .ReturnsAsync(expectedUpdated);

            // Act
            var result = await _topicService.UpdateAsync(model);

            // Assert
            Assert.AreEqual(expectedUpdated, result);
            _mockUnitOfWork.Verify(uow => uow.TopicRepository.UpdateAsync(It.IsAny<Topic>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_Should_Delete_Topic_By_Id()
        {
            // Arrange
            var id = 1;
            var expectedDeleted = true;

            _mockUnitOfWork.Setup(uow => uow.TopicRepository.DeleteAsync(id))
                .ReturnsAsync(expectedDeleted);

            // Act
            var result = await _topicService.DeleteAsync(id);

            // Assert
            Assert.AreEqual(expectedDeleted, result);
            _mockUnitOfWork.Verify(uow => uow.TopicRepository.DeleteAsync(id), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }

        // Add more test methods as needed

        [TearDown]
        public void TearDown()
        {
            _topicService = null;
            _mockUnitOfWork = null;
            _mapper = null;
        }
    }
}
