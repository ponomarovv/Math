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


namespace Math.DAL.Impl.Tests.Repository;

[TestFixture]
public class QuestionRepositoryTests
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
        // context.Database.Migrate();
        await context.Database.EnsureCreatedAsync();
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
        
    [Test]
    public async Task CreateQuestion_Should_Add_New_Question()
    {
        // Arrange
        using var context = new MathContext(_options);
        await context.Database.EnsureCreatedAsync();
        var repository = new QuestionRepository(context);

        var question = new Question { Text = "TestQuestion" };

        // Act
        await repository.AddAsync(question);

        // Assert
        var createdQuestion = await repository.GetByIdAsync(question.Id);
        Assert.NotNull(createdQuestion);
        Assert.AreEqual("TestQuestion", createdQuestion.Text);
    }

    [Test]
    public async Task ReadQuestion_Should_Return_Existing_Question()
    {
        // Arrange
        using var context = new MathContext(_options);
        await context.Database.EnsureCreatedAsync();
        var repository = new QuestionRepository(context);

        var question = new Question { Text = "TestQuestion" };
        await repository.AddAsync(question);

        // Act
        var retrievedQuestion = await repository.GetByIdAsync(question.Id);

        // Assert
        Assert.NotNull(retrievedQuestion);
        Assert.AreEqual("TestQuestion", retrievedQuestion.Text);
    }

    [Test]
    public async Task DeleteQuestion_Should_Remove_Existing_Question()
    {
        // Arrange
        using var context = new MathContext(_options);
        await context.Database.EnsureCreatedAsync();
        var repository = new QuestionRepository(context);

        var question = new Question { Text = "TestQuestion" };
        await repository.AddAsync(question);

        // Act
        var deleted = await repository.DeleteAsync(question.Id);

        // Assert
        Assert.IsTrue(deleted);

        // Verify the question is deleted
        var deletedQuestion = await repository.GetByIdAsync(question.Id);
        Assert.Null(deletedQuestion);
    }
    
    [Test]
    public async Task GetAllQuestions_Should_Return_All_Questions()
    {
       // Arrange
        using var context = new MathContext(_options);
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        var repository = new QuestionRepository(context);

        var questions = new List<Question>
        {
            new Question { Text = "Question 1" },
            new Question { Text = "Question 2" },
            new Question { Text = "Question 3" }
        };

        foreach (var question in questions)
        {
            await repository.AddAsync(question);
        }

        // Act
        var allQuestions = await repository.GetAllAsync(x=>true);

        // Assert
        Assert.NotNull(allQuestions);
        Assert.AreEqual(3, allQuestions.Count);
        Assert.IsTrue(allQuestions.Any(q => q.Text == "Question 1"));
        Assert.IsTrue(allQuestions.Any(q => q.Text == "Question 2"));
        Assert.IsTrue(allQuestions.Any(q => q.Text == "Question 3"));
    }

}


