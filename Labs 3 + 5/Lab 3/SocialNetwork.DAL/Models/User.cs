using System.Collections.Generic;

namespace SocialNetwork.DAL.Models
{
    public class User
    {
        public User(string name, string password)
        {
            amount++;
            Name = name;
            Password = password;
            UsersRequestFrom = new List<User>();
            UsersRequestFrom = new List<User>();
            Friends = new List<User>();
            Host = amount;
        }

        private static int amount = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Host { get; set; }

        public List<User> UsersRequestFrom { get; set; }

        public List<User> Friends { get; set; }
    }
}
