using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using Entities.Auth.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Math.WEB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationUserController : ControllerBase
{
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _singInManager;
    private readonly IConfiguration _configuration;
    private readonly ApplicationSettings _appSettings;

    public ApplicationUserController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings, IConfiguration configuration)
    {
        _userManager = userManager;
        _singInManager = signInManager;
        _configuration = configuration;
        _appSettings = appSettings.Value;
    }

    [HttpPost]
    [Route("Register")]
    //POST : /api/ApplicationUser/Register
    public async Task<Object> PostApplicationUser(ApplicationUserModel model)
    {
        var applicationUser = new ApplicationUser()
        {
            UserName = model.UserName,
            Email = model.Email,
            FullName = model.FullName
        };

        try
        {
            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            return Ok(result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    [HttpPost]
    [Route("Login")]
    //POST : /api/ApplicationUser/Login
    public async Task<IActionResult> Login(LoginModel model)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"]);

        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return Ok(new { token });
        }
        else
            return BadRequest(new {message = "Username or password is incorrect."});
    }



    [HttpDelete]
    [Route("Delete/{userId}")]
    // DELETE : /api/ApplicationUser/Delete/{userId}
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest(result.Errors);
    }
    
    
    [HttpPatch]
    [Route("Update/{Id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateModel model)
    {
        // Find the user by ID in the database
        var user =  await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound(); // User not found
        }

        // Update the user's properties
        user.FullName = model.FullName;
        user.Email = model.Email;

        // Save the changes to the database
        await _userManager.UpdateAsync(user);

        return Ok();
    }
}
