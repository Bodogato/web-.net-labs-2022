using SocialNetwork.DAL.EF;

namespace SocialNetwork.DAL.Repositories
{
    public class UnitOfWork
    {
        SocialNetworkContext db;

        public UnitOfWork(SocialNetworkContext _db, MessageRepository messageRepository, UserRepository userRepository, NetworkRepository networkRepository)
        {
            db = _db;
            MessageRepository = messageRepository;
            UserRepository = userRepository;
            NetworkRepository = networkRepository;
        }
        
        public void Save()
        {
            db.SaveChanges();
        }

        public MessageRepository MessageRepository { get; set; }

        public NetworkRepository NetworkRepository { get; set; }

        public UserRepository UserRepository { get; set; }
    }
}
