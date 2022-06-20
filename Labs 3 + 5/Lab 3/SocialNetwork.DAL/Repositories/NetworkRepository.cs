using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DAL.Repositories
{
    public class NetworkRepository : IRepository<Network>
    {
        private readonly SocialNetworkContext db;

        public NetworkRepository(SocialNetworkContext _db)
        {
            db = _db;
        }

        public void Add(Network entity)
        {
           db.Networks.Add(entity);
           db.SaveChanges();
        }

        public void Delete(Network entity)
        {
            db.Networks.Remove(entity);
            db.SaveChanges();
        }

        public Network Get(int id)
        {
            return db.Networks.Where(x => x.Id == id).First();
        }

        public List<Network> GetAll()
        {
            return db.Networks.ToList();
        }
    }
}
