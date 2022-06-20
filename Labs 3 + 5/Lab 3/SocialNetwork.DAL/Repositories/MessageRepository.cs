using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DAL.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly SocialNetworkContext db;

        public MessageRepository(SocialNetworkContext _db)
        {
            db = _db;   
        }

        public void Add(Message entity)
        {
            foreach (var item in db.Networks.ToList())
            {
                if(item.Id == entity.NetworkId)
                {
                    foreach (var user in item.Users)
                    {
                        if(entity.UserId == user.Id)
                        {
                            item.Messages.Add(entity);
                            db.Messages.Add(entity);
                            db.SaveChanges();
                        }
                    }
                }
            }
            db.SaveChanges();
        }

        public void Delete(Message entity)
        {
            db.Messages.Remove(entity);
            foreach (var item in db.Networks.ToList())
            {
                if (item.Id == entity.NetworkId)
                {
                    item.Messages.Remove(entity);
                }
            }
            db.SaveChanges();
        }

        public Message Get(int id)
        {
            return db.Messages.Where(x => x.Id == id).First();
        }

        public List<Message> GetAll()
        {
            return db.Messages.ToList();
        }

        public List<Message> GetAllByGroupId(int id)
        {
            foreach (var item in db.Networks.ToList())
            {
                if(item.Id == id)
                {
                    return item.Messages.ToList();
                }
            }
            return null;
        }
    }
}
