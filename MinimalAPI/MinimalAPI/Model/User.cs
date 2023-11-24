namespace MinimalAPI.Model
{
    public class User
    {
        public User(string name, string email) 
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
    }
}
