using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;

namespace RecipeApp.Data
{
    public class RecipesContext: DbContext {
        public DbSet<User> users {get; set;}
        public DbSet<Choice> choices {get; set;}

        public RecipesContext(DbContextOptions<RecipesContext> options): base(options) {}
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}