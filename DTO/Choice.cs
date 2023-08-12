namespace RecipeApp.DTO {
    public class ChoiceDTO {
        public int id { get; set; }

        public string title { get; set; }
        public int votes { get; set; }
        public DateTime createdAt {get; set;} = DateTime.UtcNow;
        public DateTime updatedAt {get; set;} = DateTime.UtcNow;

    }
}