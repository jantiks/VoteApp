
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecipeApp.Data;
using RecipeApp.Models;
using Microsoft.EntityFrameworkCore;
using RecipeApp.DTO;
using Microsoft.AspNetCore.Cors;

namespace RecipesApi.Controllers;


[ApiController]
[Route("[controller]"), EnableCors()]
    public class AuthController : ControllerBase 
    {
      public IConfiguration Configuration { get; set; }
      public RecipesContext Context { get; set; }

    public AuthController(IConfiguration configuration, RecipesContext context) {
      Configuration = configuration;
      Context = context;
    }

    string CreateToken(User user)
    {
      var section = Configuration.GetSection("JWT");
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section.GetValue<string>("Token")));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var issuer = section.GetValue<string>("Issuer");
      var audience = section.GetValue<string>("Audience");
      var jwtValidity = DateTime.Now.AddHours(section.GetValue<int>("ExpirationHours"));

      var token = new JwtSecurityToken(
        issuer,
        audience,
        new List<Claim>() {
          new Claim("id", user.id.ToString()),
          new Claim("username", user.userName),
        },
        expires: jwtValidity,
        signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("/Login")]
    public async Task<ActionResult<string>> Login(LoginUserDTO User) {
      var foundUser = await Context
        .users
        .Where(u => u.userName == User.userName)
        .FirstOrDefaultAsync();
      if (foundUser == null) {
        return NotFound(new { message = "Not Found" });
      }

      var valid = BCrypt.Net.BCrypt.Verify(User.password, foundUser.password);

      if (valid) {
        return Ok(new { token = CreateToken(foundUser) });
      }

      return BadRequest(new { message = "Bad Password" });
    }
}
