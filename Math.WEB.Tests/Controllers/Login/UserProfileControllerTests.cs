using System.Security.Claims;
using Entities;
using Entities.Auth.Login;
using Math.WEB.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Math.WEB.Tests.Controllers
{
    [TestFixture]
    public class UserProfileControllerTests
    {
        private UserProfileController _userProfileController;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IOptions<ApplicationSettings>> _mockAppSettings;

        [SetUp]
        public void Setup()
        {
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null);

            _mockConfiguration = new Mock<IConfiguration>();
            _mockAppSettings = new Mock<IOptions<ApplicationSettings>>();
            
            _userProfileController = new UserProfileController(
                _mockUserManager.Object,
                null, // You can mock the SignInManager if needed
                _mockConfiguration.Object,
                _mockAppSettings.Object
            );
        }

        [Test]
        public async Task GetUserProfile_ReturnsUserProfile()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "testuserid",
                FullName = "Test User",
                Email = "testuser@example.com",
                UserName = "testuser",
                PasswordHash = "hashedpassword"
            };

            var claims = new[]
            {
                new Claim("UserID", user.Id)
            };

            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims));

            _userProfileController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(user.Id))
                .ReturnsAsync(user);

            // Act
            var userProfile = await _userProfileController.GetUserProfile();

            /// Assert
            Assert.IsNotNull(userProfile);
            Assert.AreEqual(user.Id, userProfile.Id);
            Assert.AreEqual(user.FullName, userProfile.FullName);
            Assert.AreEqual(user.Email, userProfile.Email);
            Assert.AreEqual(user.UserName, userProfile.UserName);
            Assert.AreEqual(user.PasswordHash, userProfile.PasswordHash);
        }
    }
}
