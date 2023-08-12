using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Models  {
    public class Choice: BaseModel {
        [Required, MinLength(2), MaxLength(30)]
        public string title { get; set; }
        public int votes { get; set; } = 0;
        public List<int> votedIds {get; set; }
    }
} 