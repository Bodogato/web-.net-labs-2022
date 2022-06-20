using System.Collections.Generic;

namespace SocialNetwork.DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
