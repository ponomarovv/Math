using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Math.DAL.Abstract.Repository;
using Math.DAL.Context;
using Math.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Impl.Tests.Repository
{
    [TestFixture]
    public class AnswerRepositoryTests
    {
        private DbContextOptions<MathContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<MathContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Test]
        public async Task TestUpdateAnswer()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new AnswerRepository(context);

            var originalAnswer = new Answer { Text = "TestAnswer" };
            await repository.AddAsync(originalAnswer);

            // Act
            originalAnswer.Text = "UpdatedAnswer";
            await repository.UpdateAsync(originalAnswer);

            // Assert
            var updatedAnswer = await repository.GetByIdAsync(originalAnswer.Id);
            Assert.NotNull(updatedAnswer);
            Assert.AreEqual("UpdatedAnswer", updatedAnswer.Text);
        }

        [Test]
        public async Task CreateAnswer_Should_Add_New_Answer()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new AnswerRepository(context);

            var answer = new Answer { Text = "TestAnswer" };

            // Act
            await repository.AddAsync(answer);

            // Assert
            var createdAnswer = await repository.GetByIdAsync(answer.Id);
            Assert.NotNull(createdAnswer);
            Assert.AreEqual("TestAnswer", createdAnswer.Text);
        }

        [Test]
        public async Task ReadAnswer_Should_Return_Existing_Answer()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new AnswerRepository(context);

            var answer = new Answer { Text = "TestAnswer" };
            await repository.AddAsync(answer);

            // Act
            var retrievedAnswer = await repository.GetByIdAsync(answer.Id);

            // Assert
            Assert.NotNull(retrievedAnswer);
            Assert.AreEqual("TestAnswer", retrievedAnswer.Text);
        }

        [Test]
        public async Task DeleteAnswer_Should_Remove_Existing_Answer()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new AnswerRepository(context);

            var answer = new Answer { Text = "TestAnswer" };
            await repository.AddAsync(answer);

            // Act
            var deleted = await repository.DeleteAsync(answer.Id);

            // Assert
            Assert.IsTrue(deleted);

            // Verify the answer is deleted
            var deletedAnswer = await repository.GetByIdAsync(answer.Id);
            Assert.Null(deletedAnswer);
        }

        [Test]
        public async Task GetAllAnswers_Should_Return_All_Answers()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            var repository = new AnswerRepository(context);

            var answers = new List<Answer>
            {
                new Answer { Text = "Answer 1" },
                new Answer { Text = "Answer 2" },
                new Answer { Text = "Answer 3" }
            };

            foreach (var answer in answers)
            {
                await repository.AddAsync(answer);
            }

            // Act
            var allAnswers = await repository.GetAllAsync(x => true);

            // Assert
            Assert.NotNull(allAnswers);
            Assert.AreEqual(3, allAnswers.Count);
            Assert.IsTrue(allAnswers.Any(a => a.Text == "Answer 1"));
            Assert.IsTrue(allAnswers.Any(a => a.Text == "Answer 2"));
            Assert.IsTrue(allAnswers.Any(a => a.Text == "Answer 3"));
        }
    }
}
