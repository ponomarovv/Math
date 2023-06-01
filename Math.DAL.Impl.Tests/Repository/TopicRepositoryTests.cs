using NUnit.Framework;
using Entities.TopicEntity;
using Math.DAL.Context;
using Math.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Math.DAL.Impl.Tests.Repository
{
    [TestFixture]
    public class TopicRepositoryTests
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
        public async Task TestUpdateTopic()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new TopicRepository(context);

            var originalTopic = new Topic { Text = "TestTopic" };
            await repository.AddAsync(originalTopic);

            // Act
            originalTopic.Text = "UpdatedTopic";
            await repository.UpdateAsync(originalTopic);

            // Assert
            var updatedTopic = await repository.GetByIdAsync(originalTopic.Id);
            Assert.NotNull(updatedTopic);
            Assert.AreEqual("UpdatedTopic", updatedTopic.Text);
        }

        [Test]
        public async Task CreateTopic_Should_Add_New_Topic()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new TopicRepository(context);

            var topic = new Topic { Text = "TestTopic" };

            // Act
            await repository.AddAsync(topic);

            // Assert
            var createdTopic = await repository.GetByIdAsync(topic.Id);
            Assert.NotNull(createdTopic);
            Assert.AreEqual("TestTopic", createdTopic.Text);
        }

        [Test]
        public async Task ReadTopic_Should_Return_Existing_Topic()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new TopicRepository(context);

            var topic = new Topic { Text = "TestTopic" };
            await repository.AddAsync(topic);

            // Act
            var retrievedTopic = await repository.GetByIdAsync(topic.Id);

            // Assert
            Assert.NotNull(retrievedTopic);
            Assert.AreEqual("TestTopic", retrievedTopic.Text);
        }

        [Test]
        public async Task DeleteTopic_Should_Remove_Existing_Topic()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureCreatedAsync();
            var repository = new TopicRepository(context);

            var topic = new Topic { Text = "TestTopic" };
            await repository.AddAsync(topic);

            // Act
            var deleted = await repository.DeleteAsync(topic.Id);

            // Assert
            Assert.IsTrue(deleted);

            // Verify the topic is deleted
            var deletedTopic = await repository.GetByIdAsync(topic.Id);
            Assert.Null(deletedTopic);
        }

        [Test]
        public async Task GetAllTopics_Should_Return_All_Topics()
        {
            // Arrange
            using var context = new MathContext(_options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            var repository = new TopicRepository(context);

            var topics = new List<Topic>
            {
                new Topic { Text = "Topic 1" },
                new Topic { Text = "Topic 2" },
                new Topic { Text = "Topic 3" }
            };

            foreach (var topic in topics)
            {
                await repository.AddAsync(topic);
            }

            // Act
            var allTopics = await repository.GetAllAsync(x => true);

            // Assert
            Assert.NotNull(allTopics);
            Assert.AreEqual(3, allTopics.Count);
            Assert.IsTrue(allTopics.Any(t => t.Text == "Topic 1"));
            Assert.IsTrue(allTopics.Any(t => t.Text == "Topic 2"));
            Assert.IsTrue(allTopics.Any(t => t.Text == "Topic 3"));
        }
    }
}
