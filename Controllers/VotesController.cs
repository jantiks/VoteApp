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
using RecipesApi.Migrations;

namespace RecipesApi.Controllers;

[ApiController]
[Route("[controller]"), EnableCors()]
public class VotesController : ControllerBase
{
    RecipesContext Context { get; set; }
    public VotesController(RecipesContext context) {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Choice>>> Get()
    {
       var choices = await Context
       .choices
       .ToListAsync();
       
       return Ok(choices.Select(c => new ChoiceDTO() {
            id = c.id,
            title = c.title,
            votes = c.votes,
            createdAt = c.createdAt,
            updatedAt = c.updatedAt,
       }));
    }
    [HttpPost("/addChoice")]
    public async Task<ActionResult<IEnumerable<ChoiceDTO>>> Post(Choice choice)
    {   
        var foundChoice = await Context
        .choices
        .Where(c => c.id == choice.id)
        .FirstOrDefaultAsync();
        
        if (foundChoice == null) {
            await Context.choices.AddAsync(choice);
            await Context.SaveChangesAsync();

            return Ok(new ChoiceDTO() {
                id = choice.id,
                title = choice.title,
                votes = choice.votes,
                createdAt = choice.createdAt,
                updatedAt = choice.updatedAt,
            });
        }

        return BadRequest(new { message = "Choice with id exists" });      
    }

    [HttpPost("/removeChoice")]
    public async Task<ActionResult<IEnumerable<ChoiceDTO>>> removeChoice(int id) 
    {
        var foundChoice = await Context
        .choices
        .Where(c => c.id == id)
        .FirstOrDefaultAsync();
        if (foundChoice == null) {
            return BadRequest(new { message = "Coudn't find the choice with this id" });
        }

        Context.choices.Remove(foundChoice);
        await Context.SaveChangesAsync();

        return Ok(new { message = $"Deleted Successfullyy {id}" });
    }


    [HttpPost("/updateChoice")]
    public async Task<ActionResult<IEnumerable<ChoiceDTO>>> updateChoice(ChoiceDTO choice)
    {   
        var foundChoice = await Context
        .choices
        .Where(c => c.id == choice.id)
        .FirstOrDefaultAsync();
        if (foundChoice == null) {
            return BadRequest(new { message = "Coudn't find the choice with this id" });
        }
        foundChoice.title = choice.title;
        foundChoice.votes = choice.votes;
        Context.Update(foundChoice);
        await Context.SaveChangesAsync();

        return Ok(new ChoiceDTO() {
            id = foundChoice.id,
            title = foundChoice.title,
            votes = foundChoice.votes,
            createdAt = foundChoice.createdAt,
            updatedAt = foundChoice.updatedAt
        });
    }

    [HttpPost("/incrementChoice")]
    public async Task<ActionResult<IEnumerable<string>>> incrementChoice(int id)
    {   
        var foundChoice = await Context
        .choices
        .Where(c => c.id == id)
        .FirstOrDefaultAsync();
        if (foundChoice == null) {
            return BadRequest(new { message = "Coudn't find the choice with this id" });
        }
        foundChoice.votes += 1;
        Context.Update(foundChoice);
        await Context.SaveChangesAsync();

        return Ok(new { message = $"Success vote count: {foundChoice.votes}" });
    }
}
