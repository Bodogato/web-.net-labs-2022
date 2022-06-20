using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PL;
using System;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SocialNetworkContext("1dedf4feds2d2216turt");
            var menu = new Menu(new SocialNetworkService(new UnitOfWork(db, new MessageRepository(db), new UserRepository(db), new NetworkRepository(db))));
            menu.ShowUserMenu();
        }
    }
}
