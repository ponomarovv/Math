using Entities.Auth;
using Entities.Auth.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Math.WEB.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }
        
        [HttpGet]
        [Authorize]
        // GET : /api/UserProfile
        public async Task<ConfirmationModel> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = _userManager.FindByIdAsync(userId).Result;
            return new ConfirmationModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash
            };
        }
    }
}
