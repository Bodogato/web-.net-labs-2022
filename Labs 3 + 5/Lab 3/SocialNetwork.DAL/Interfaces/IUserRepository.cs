using SocialNetwork.DAL.Models;

namespace SocialNetwork.DAL.Interfaces
{
    internal interface IUserRepository: IRepository<User>
    {
        void SendRequest(User from, User to);
        void AcceptRequest(User from, User to);
    }
}
