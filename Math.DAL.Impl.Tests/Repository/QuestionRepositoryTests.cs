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
    public class RepositoryTests
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
        public async Task TestUpdateProduct()
        {
            // Arrange
            using var context = new MathContext(_options);
            context.Database.Migrate();
            // await context.Database.EnsureCreatedAsync();
            var repository = new QuestionRepository(context);

            var originalProduct = new Question { Text = "TestProduct" };
            await repository.AddAsync(originalProduct);

            // Act
            originalProduct.Text = "UpdatedProduct";
            await repository.UpdateAsync(originalProduct);

            // Assert
            var updatedProduct = await repository.GetByIdAsync(originalProduct.Id);
            Assert.NotNull(updatedProduct);
            Assert.AreEqual("UpdatedProduct", updatedProduct.Text);
        }
    }
}
