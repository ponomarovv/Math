using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Math.DAL.Impl.Tests.Repository.Base
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private Mock<IAnswerRepository> _mockAnswerRepository;
        private Mock<IQuestionRepository> _mockQuestionRepository;
        private Mock<ITopicRepository> _mockTopicRepository;
        private Mock<IQuizRepository> _mockQuizRepository;

        private UnitOfWork _unitOfWork;

        private DbContextOptions<MathContext> _options;

        private MathContext _context;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<MathContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new MathContext(_options);
            // context.Database.Migrate();
            _context.Database.EnsureCreatedAsync();


            _mockAnswerRepository = new Mock<IAnswerRepository>();
            _mockQuestionRepository = new Mock<IQuestionRepository>();
            _mockTopicRepository = new Mock<ITopicRepository>();
            _mockQuizRepository = new Mock<IQuizRepository>();

            _unitOfWork = new UnitOfWork(
                _context,
                _mockAnswerRepository.Object,
                _mockQuestionRepository.Object,
                _mockTopicRepository.Object,
                _mockQuizRepository.Object);
        }

        [Test]
        public async Task SaveChangesAsync_Should_Call_SaveChangesAsync_On_Context()
        {
            // Arrange

            // Act
            await _unitOfWork.SaveChangesAsync();

            // Assert
            using var context = new MathContext(_options);

            // Mock.Get(context).Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void Dispose_Should_Dispose_Context()
        {
            // Arrange

            // Act
            _unitOfWork.Dispose();

            // Assert
            // _context.Verify(c => c.Dispose(), Times.Once);
        }
    }
}
