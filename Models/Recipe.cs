using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp.Models 
{
    public class Recipe: BaseModel {
        [Required, MaxLength(100)]
        public string title {get; set;}
        [Required, MaxLength(1000)]
        public string content {get; set;}
        [MaxLength(2048)]
        public string imageUrl {get; set;}

        public int creatorId {get; set;}
        [ForeignKey("creatorId")]

        public User creator {get; set;}

    }
}