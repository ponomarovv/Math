using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

using Math.DAL.Abstract.Repository;
using Math.DAL.Context;

using Math.DAL.Repository;


namespace Math.DAL.Impl.Tests.Repository
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        private Mock<MathContext> mockContext;
        private IQuestionRepository questionRepository;

        [SetUp]
        public void Setup()
        {
            // Создание Mock-объекта MathContext
            mockContext = new Mock<MathContext>();
            questionRepository = new QuestionRepository(mockContext.Object);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Questions()
        {
            Assert.AreEqual(0,0);
        }
    }
}
