using Moq;
using NUnit.Framework;
using System;
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
    public class QuizRepositoryTests
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
        public async Task TestUpdateQuiz()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new QuizRepository(context);

            var originalQuiz = new Quiz { QuizDate = DateTime.Now };
            await repository.AddAsync(originalQuiz);

            // Act
            originalQuiz.QuizDate = DateTime.Now.AddDays(1);
            await repository.UpdateAsync(originalQuiz);

            // Assert
            var updatedQuiz = await repository.GetByIdAsync(originalQuiz.Id);
            Assert.NotNull(updatedQuiz);
            Assert.AreEqual(originalQuiz.QuizDate, updatedQuiz.QuizDate);
        }

        [Test]
        public async Task CreateQuiz_Should_Add_New_Quiz()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new QuizRepository(context);

            var quiz = new Quiz { QuizDate = DateTime.Now };

            // Act
            await repository.AddAsync(quiz);

            // Assert
            var createdQuiz = await repository.GetByIdAsync(quiz.Id);
            Assert.NotNull(createdQuiz);
            Assert.AreEqual(quiz.QuizDate, createdQuiz.QuizDate);
        }

        [Test]
        public async Task ReadQuiz_Should_Return_Existing_Quiz()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new QuizRepository(context);

            var quiz = new Quiz { QuizDate = DateTime.Now };
            await repository.AddAsync(quiz);

            // Act
            var retrievedQuiz = await repository.GetByIdAsync(quiz.Id);

            // Assert
            Assert.NotNull(retrievedQuiz);
            Assert.AreEqual(quiz.QuizDate, retrievedQuiz.QuizDate);
        }

        [Test]
        public async Task DeleteQuiz_Should_Remove_Existing_Quiz()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new QuizRepository(context);

            var quiz = new Quiz { QuizDate = DateTime.Now };
            await repository.AddAsync(quiz);

            // Act
            var deleted = await repository.DeleteAsync(quiz.Id);

            // Assert
            Assert.IsTrue(deleted);

            // Verify the quiz is deleted
            var deletedQuiz = await repository.GetByIdAsync(quiz.Id);
            Assert.Null(deletedQuiz);
        }

        [Test]
        public async Task GetAllQuizzes_Should_Return_All_Quizzes()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            var repository = new QuizRepository(context);

            var quizzes = new List<Quiz>
            {
                new Quiz { QuizDate = DateTime.Now },
                new Quiz { QuizDate = DateTime.Now.AddDays(1) },
                new Quiz { QuizDate = DateTime.Now.AddDays(2) }
            };

            foreach (var quiz in quizzes)
            {
                await repository.AddAsync(quiz);
            }

            // Act
            var allQuizzes = await repository.GetAllAsync(x => true);

            // Assert
            Assert.NotNull(allQuizzes);
            Assert.AreEqual(3, allQuizzes.Count);
            Assert.IsTrue(allQuizzes.Any(q => q.QuizDate == quizzes[0].QuizDate));
            Assert.IsTrue(allQuizzes.Any(q => q.QuizDate == quizzes[1].QuizDate));
            Assert.IsTrue(allQuizzes.Any(q => q.QuizDate == quizzes[2].QuizDate));
        }
    }
}
