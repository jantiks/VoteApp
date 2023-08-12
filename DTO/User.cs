namespace RecipeApp.DTO {
    public class UserDTO {
        public int id { get; set; }

        public string userName { get; set; }
        public DateTime createdAt {get; set;} = DateTime.UtcNow;
        public DateTime updatedAt {get; set;} = DateTime.UtcNow;

    }

    public class LoginUserDTO {
        public string userName { get; set; }
        public string password { get; set; }

        public LoginUserDTO(string userName, string password) {
            this.userName = userName;
            this.password = password;
        }
    }
}