using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipeApp.Models  {
    public class User: BaseModel {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string userName {get; set;}
        [Required]
        [MaxLength(500)]
        public string password {get; set;}
    }
} 