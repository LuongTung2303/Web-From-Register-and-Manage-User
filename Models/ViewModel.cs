using System.Collections.Generic;


namespace WebFormRegister.Models
{
    public class UserViewModel
    {
        public User NewUser { get; set; } = new User();
        public List<User> Users { get; set; } = new List<User>();
    }
}