using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Models {
    public class BaseModel {
        [Key]
        public int id {get; set;}
        public DateTime createdAt {get; set;} = DateTime.UtcNow;
        public DateTime updatedAt {get; set;} = DateTime.UtcNow;
    }
}