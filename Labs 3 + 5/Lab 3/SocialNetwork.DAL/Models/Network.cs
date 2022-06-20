using System.Collections.Generic;

namespace SocialNetwork.DAL.Models
{
    public class Network
    {
        public Network(int hostId)
        {
            HostId = hostId;
            Users = new List<User>();
            Messages = new List<Message>();
        }

        public int Id { get; set; }

        public int HostId { get; set; }

        public List<User> Users { get; set; }

        public List<Message> Messages { get; set; }
    }
}
