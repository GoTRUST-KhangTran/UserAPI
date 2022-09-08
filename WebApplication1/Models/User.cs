namespace WebApplication1.Models
{
    public class User
    {
        public User(string userName, string name, int age, string address)
        {
            UserName = userName;
            Name = name;
            Age = age;
            Address = address;
        }

        public string UserName { get; set; } 
        public string Name{ get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
