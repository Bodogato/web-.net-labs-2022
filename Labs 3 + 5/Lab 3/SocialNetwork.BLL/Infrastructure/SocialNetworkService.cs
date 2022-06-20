using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Infrastructure
{
    public class SocialNetworkService
    {
        public SocialNetworkService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UnitOfWork UnitOfWork { get; set; }
    }
}
