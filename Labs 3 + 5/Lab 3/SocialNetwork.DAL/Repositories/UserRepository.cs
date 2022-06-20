using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkContext db;

        public UserRepository(SocialNetworkContext _db)
        {
            db = _db;
        }

        public void AcceptRequest(User from, User to)
        {
            foreach (var item in db.Users.ToList())
            {
                if(item.Id == to.Id)
                {
                    from.Friends.Add(item);
                    from.UsersRequestFrom.Remove(item);
                    to.UsersRequestFrom.Remove(from);
                    to.Friends.Add(from);
                    foreach (var network in db.Networks.ToList())
                    {
                        System.Console.WriteLine(network.HostId);
                        if(network.HostId == from.Id)
                        {
                            network.Users.Add(to);
                        }
                        else if(network.HostId == to.Id)
                        {
                            network.Users.Add(from);
                        }
                    }
                }
            }
            db.SaveChanges();
        }

        public void Add(User entity)
        {
            db.Users.Add(entity);
            var net = new Network(entity.Host);
            net.Users.Add(entity);
            db.Networks.Add(net);
            db.SaveChanges();
        }

        public void Delete(User entity)
        {
            db.Users.Remove(entity);
            foreach (var item in db.Networks.ToList())
            {
                if(item.HostId == entity.Id)
                {
                    db.Networks.Remove(item);
                }
            }
            db.SaveChanges();
        }

        public User Get(int id)
        {
            return db.Users.Where(x => x.Id == id).First();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void SendRequest(User from, User to)
        {
            foreach (var item in db.Users.ToList())
            {
                if(item.Id == to.Id)
                {
                    to.UsersRequestFrom.Add(from);
                }
            }
            db.SaveChanges();
        }
    }
}
