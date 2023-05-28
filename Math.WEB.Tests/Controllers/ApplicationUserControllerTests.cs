using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using Entities.Auth.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Math.WEB.Controllers;
using Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Math.WEB.Tests.Controllers
{
    [TestFixture]
    public class ApplicationUserControllerTests
    {
        private ApplicationUserController _applicationUserController;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<SignInManager<ApplicationUser>> _mockSignInManager;
        private Mock<IConfiguration> _mockConfiguration;
        private IOptions<ApplicationSettings> _mockAppSettings;

        [SetUp]
        public void SetUp()
        {
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            _mockSignInManager = new Mock<SignInManager<ApplicationUser>>(
                _mockUserManager.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                null, null, null, null);

            _mockConfiguration = new Mock<IConfiguration>();
            _mockAppSettings = Options.Create(new ApplicationSettings { JWT_Secret = "test_secret" });

            _applicationUserController = new ApplicationUserController(
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockAppSettings,
                _mockConfiguration.Object);
        }

     [Test]
public async Task RegisterApplicationUser_ValidModel_ReturnsOkResult()
{
    // Arrange
    var model = new ApplicationUserModel
    {
        UserName = "testuser",
        Email = "testuser@example.com",
        Password = "testpassword",
        FullName = "Test User"
    };

    _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
        .ReturnsAsync(IdentityResult.Success);

    // Act
    var result = await _applicationUserController.PostApplicationUser(model);

    // Assert
    Assert.IsInstanceOf<OkObjectResult>(result);
}

[Test]
public async Task RegisterApplicationUser_InvalidModel_ThrowsException()
{
    // Arrange
    var model = new ApplicationUserModel
    {
        UserName = "testuser",
        Email = "testuser@example.com",
        Password = "testpassword",
        FullName = "Test User"
    };

    _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
        .ThrowsAsync(new Exception("Error creating user"));

    // Act and Assert
    Assert.ThrowsAsync<Exception>(async () => await _applicationUserController.PostApplicationUser(model));
}

[Test]
public async Task Login_ValidCredentials_ReturnsToken()
{
    // Arrange
    var model = new LoginModel
    {
        UserName = "testuser",
        Password = "testpassword"
    };

    var user = new ApplicationUser { UserName = "testuser", Id = "testuserid" };
    _mockUserManager.Setup(x => x.FindByNameAsync(model.UserName))
        .ReturnsAsync(user);
    _mockUserManager.Setup(x => x.CheckPasswordAsync(user, model.Password))
        .ReturnsAsync(true);

    _mockConfiguration.Setup(x => x["ApplicationSettings:JWT_Secret"])
        .Returns("this_is_a_test_secret_with_sufficient_length_that_is_at_least_32_bytes_long");

    string expectedToken = "this_is_a_test_token";
    var securityToken = new JwtSecurityToken();

    var _mockTokenHandler = new Mock<JwtSecurityTokenHandler>();
    _mockTokenHandler.Setup(x => x.CreateToken(It.IsAny<SecurityTokenDescriptor>()))
        .Returns(securityToken);
    _mockTokenHandler.Setup(x => x.WriteToken(securityToken))
        .Returns(expectedToken);

    // Act
    var result = await _applicationUserController.Login(model);

    // Assert
    Assert.IsInstanceOf<OkObjectResult>(result);
    // var okResult = (OkObjectResult)result;
    // var resultValue = okResult.Value as dynamic;
    // string finalVariable = resultValue?.token;
    // Assert.IsNotNull(okResult);
}



[Test]
public async Task Login_InvalidCredentials_ReturnsBadRequest()
{
    // Arrange
    var model = new LoginModel
    {
        UserName = "testuser",
        Password = "testpassword"
    };

    var user = new ApplicationUser { UserName = "testuser" };
    _mockUserManager.Setup(x => x.FindByNameAsync(model.UserName))
        .ReturnsAsync(user);
    _mockUserManager.Setup(x => x.CheckPasswordAsync(user, model.Password))
        .ReturnsAsync(false);

    _mockConfiguration.Setup(x => x["ApplicationSettings:JWT_Secret"])
        .Returns("test_secret");

    // Act
    var result = await _applicationUserController.Login(model);

    // Assert
    Assert.IsInstanceOf<BadRequestObjectResult>(result);
}


[Test]
public async Task DeleteUser_ExistingUser_ReturnsNoContent()
{
    // Arrange
    var userId = "testuser123";
    var user = new ApplicationUser { Id = userId };

    _mockUserManager.Setup(x => x.FindByIdAsync(userId))
        .ReturnsAsync(user);
    _mockUserManager.Setup(x => x.DeleteAsync(user))
        .ReturnsAsync(IdentityResult.Success);

    // Act
    var result = await _applicationUserController.DeleteUser(userId);

    // Assert
    Assert.IsInstanceOf<NoContentResult>(result);
}

[Test]
public async Task DeleteUser_NonExistingUser_ReturnsNotFound()
{
    // Arrange
    var userId = "testuser123";

    _mockUserManager.Setup(x => x.FindByIdAsync(userId))
        .ReturnsAsync((ApplicationUser)null);

    // Act
    var result = await _applicationUserController.DeleteUser(userId);

    // Assert
    Assert.IsInstanceOf<NotFoundResult>(result);
}

[Test]
public async Task UpdateUser_ExistingUser_ReturnsOkResult()
{
    // Arrange
    var userId = "testuser123";
    var model = new UserUpdateModel
    {
        FullName = "Updated User",
        Email = "updateduser@example.com"
    };

    var user = new ApplicationUser { Id = userId };

    _mockUserManager.Setup(x => x.FindByIdAsync(userId))
        .ReturnsAsync(user);
    _mockUserManager.Setup(x => x.UpdateAsync(user))
        .ReturnsAsync(IdentityResult.Success);

    // Act
    var result = await _applicationUserController.UpdateUser(userId, model);

    // Assert
    Assert.IsInstanceOf<OkResult>(result);
}

[Test]
public async Task UpdateUser_NonExistingUser_ReturnsNotFound()
{
    // Arrange
    var userId = "testuser123";
    var model = new UserUpdateModel
    {
        FullName = "Updated User",
        Email = "updateduser@example.com"
    };

    _mockUserManager.Setup(x => x.FindByIdAsync(userId))
        .ReturnsAsync((ApplicationUser)null);

    // Act
    var result = await _applicationUserController.UpdateUser(userId, model);

    // Assert
    Assert.IsInstanceOf<NotFoundResult>(result);
}


        [TearDown]
        public void TearDown()
        {
            _applicationUserController = null;
            _mockUserManager = null;
            _mockSignInManager = null;
            _mockConfiguration = null;
            _mockAppSettings = null;
        }
    }
}
