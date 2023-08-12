using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Models  {
    public class Vote: BaseModel {
        [Required, MinLength(2), MaxLength(30)]
        public string title { get; set; }
        public ICollection<Choice> choices { get; set; }
        public ICollection<User> users{ get; set; }
    }
} 