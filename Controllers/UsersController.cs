using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using RecipeApp.Models;
using BCrypt.Net;
using RecipeApp.DTO;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace RecipesApi.Controllers;

[ApiController]
[Route("[controller]"), EnableCors()]
public class UsersController : ControllerBase
{
    RecipesContext Context { get; set; }
    public UsersController(RecipesContext context) {
        Context = context;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
    {
       var users = await Context
       .users
       .ToListAsync();
       
       return Ok(users.Select(user => new UserDTO() {
            id = user.id,
            userName = user.userName,
            createdAt = user.createdAt,
            updatedAt = user.updatedAt,
       }));
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Post(User user)
    {   
        var foundUser = await Context
        .users
        .Where(u => u.userName == user.userName)
        .FirstOrDefaultAsync();
      if (foundUser == null) {
        user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
        await Context.users.AddAsync(user);
        await Context.SaveChangesAsync();
        return Ok(new UserDTO() {
            id = user.id,
            userName = user.userName,
            createdAt = user.createdAt,
            updatedAt = user.updatedAt,
        });
      }

      return BadRequest(new { message = "User already exists" });
    }
}
