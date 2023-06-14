using Entities;
using Math.DAL.Context;
using Math.DAL.Repository;
using Math.DAL.Repository.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Math.DAL.Impl.Tests.Repository.Base
{
    [TestFixture]
    public class GenericRepositoryTests
    {
        private MathContext _context;
        private GenericRepository<int, Question> _repository;
        private DbContextOptions<MathContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<MathContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new MathContext(_options);
            _repository = new QuestionRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task AddAsync_Should_Add_Entity_To_Database()
        {
            // Arrange
            var product = new Question {  Text = "TestProduct" };

            // Act
            var addedProduct = await _repository.AddAsync(product);

            // Assert
            Assert.NotNull(addedProduct);
            Assert.AreEqual(product.Id, addedProduct.Id);
            Assert.AreEqual(product.Text, addedProduct.Text);

            using (var context = new MathContext(_options))
            {
                var retrievedProduct = await context.Questions.FindAsync(product.Id);
                Assert.NotNull(retrievedProduct);
                Assert.AreEqual(product.Id, retrievedProduct.Id);
                Assert.AreEqual(product.Text, retrievedProduct.Text);
            }
        }

        [Test]
        public async Task DeleteAsync_Should_Delete_Entity_From_Database()
        {
            // Arrange
            var product = new Question { Id = 1, Text = "TestProduct" };
            await _context.Questions.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteAsync(product.Id);

            // Assert
            Assert.True(result);

            using (var context = new MathContext(_options))
            {
                var deletedProduct = await context.Questions.FindAsync(product.Id);
                Assert.Null(deletedProduct);
            }
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Entity_In_Database()
        {
            // Arrange
            var product = new Question { Id = 1, Text = "TestProduct" };
            await _context.Questions.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            product.Text = "UpdatedProduct";
            var result = await _repository.UpdateAsync(product);

            // Assert
            Assert.True(result);

            using var context = new MathContext(_options);

            var updatedProduct = await context.Questions.FindAsync(product.Id);
            Assert.NotNull(updatedProduct);
            Assert.AreEqual(product.Id, updatedProduct.Id);
            Assert.AreEqual(product.Text, updatedProduct.Text);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Entities_Satisfying_Predicate()
        {
            // Arrange
            var products = new List<Question>
            {
                new Question { Id = 1, Text = "TestProduct1" },
                new Question { Id = 2, Text = "TestProduct2" },
                new Question { Id = 3, Text = "OtherProduct" }
            };
            await _context.Questions.AddRangeAsync(products);
            await _context.SaveChangesAsync();

            // Act
            // var tempResult = await _repository.GetAllAsync(x=>true);
            var result = await _repository.GetAllAsync(p => p.Text.StartsWith("Test"));

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.True(result.All(p => p.Text.StartsWith("Test")));
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Entity_With_Given_Id()
        {
            // Arrange
            var product = new Question { Id = 1, Text = "TestProduct" };
            await _context.Questions.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(product.Id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(product.Id, result.Id);
            Assert.AreEqual(product.Text, result.Text);
        }
    }
}
