using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.DAL.Models;
using System;

namespace SocialNetwork.PL
{
    public class Menu
    {
        private SocialNetworkService service;

        public Menu(SocialNetworkService _service)
        {
            service = _service;
        }

        public void ShowUserMenu()
        {
            int choosen;
            bool run = true;
            try
            {

                while (run)
                {
                    Console.WriteLine("Enter 1 to add user\nEnter 2 to delete user\nEnter 3 to print all users\nEnter 4 to send friend request\nEnter 5 to apply friend request\nEnter 6 to send message\nEnter 7 to show all messages from your chats\nEnter 8 to check all friends by user id\nEnter 9 to stop running program");
                    choosen = Convert.ToInt32(Console.ReadLine());
                    switch (choosen)
                    {
                        case 1:
                            {
                                string name, pass;
                                Console.WriteLine("Enter user name: ");
                                name = Console.ReadLine();
                                Console.WriteLine("Enter password: ");
                                pass = Console.ReadLine();
                                service.UnitOfWork.UserRepository.Add(new User(name, pass));
                                Console.WriteLine("Done!");
                                break;
                            }
                        case 2:
                            {
                                int id;
                                Console.WriteLine("Ener id to delete it");
                                id = Convert.ToInt32(Console.ReadLine());
                                service.UnitOfWork.UserRepository.Delete(service.UnitOfWork.UserRepository.Get(id));
                                Console.WriteLine("Done!");
                                break;
                            }
                        case 3:
                            {
                                foreach (var item in service.UnitOfWork.UserRepository.GetAll())
                                {
                                    Console.WriteLine("Id: " + item.Id + ". Name: "  + item.Name);
                                }
                                break;
                            }
                        case 4:
                            {
                                int idTo, idFrom;
                                string password;
                                Console.WriteLine("Enter user sender`s id");
                                idFrom = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter user sender`s password");
                                password = Console.ReadLine();
                                Console.WriteLine("Enter user recipient`s id");
                                idTo = Convert.ToInt32(Console.ReadLine());
                                if (service.UnitOfWork.UserRepository.Get(idFrom).Password != password)
                                {
                                    throw new Exception("Password error");
                                }
                                service.UnitOfWork.UserRepository.SendRequest(service.UnitOfWork.UserRepository.Get(idFrom), service.UnitOfWork.UserRepository.Get(idTo));
                                Console.WriteLine("Done!");
                                break;
                            }
                        case 5:
                            {
                                string password;
                                int id, idApply;
                                Console.WriteLine("Enter user`s id");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter user`s password");
                                password = Console.ReadLine();
                                Console.WriteLine("Enter user`s id that need to be applied");
                                idApply = Convert.ToInt32(Console.ReadLine());
                                if (service.UnitOfWork.UserRepository.Get(id).Password != password)
                                {
                                    throw new Exception("Password error");
                                }
                                service.UnitOfWork.UserRepository.AcceptRequest(service.UnitOfWork.UserRepository.Get(id), service.UnitOfWork.UserRepository.Get(idApply));
                                Console.WriteLine("Done!");
                                break;
                            }
                        case 6:
                            {
                                int idFrom, idNetwork;
                                string password, text;
                                Console.WriteLine("Enter user sender`s id");
                                idFrom = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter user sender`s password");
                                password = Console.ReadLine();
                                Console.WriteLine("Enter network`s id");
                                idNetwork = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter message`s text");
                                text = Console.ReadLine();
                                if (service.UnitOfWork.UserRepository.Get(idFrom).Password != password)
                                {
                                    throw new Exception("Password error");
                                }
                                service.UnitOfWork.MessageRepository.Add(new Message(idFrom, idNetwork, text));
                                service.UnitOfWork.Save();
                                Console.WriteLine("Done!");
                                break;
                            }
                        case 7:
                            {
                                int idChat;
                                Console.WriteLine("Enter chat id");
                                idChat = Convert.ToInt32(Console.ReadLine());
                                foreach (var item in service.UnitOfWork.MessageRepository.GetAllByGroupId(idChat))
                                {
                                    Console.WriteLine("UserId: " + item.UserId + ". Text: " + item.Text);
                                }
                                break;
                            }
                        case 8:
                            {
                                int id;
                                Console.WriteLine("Enter user`s id");
                                id = Convert.ToInt32(Console.ReadLine());
                                foreach (var item in service.UnitOfWork.UserRepository.GetAll())
                                {
                                    if(item.Id == id)
                                    {
                                        foreach (var friend in item.Friends)
                                        {
                                            Console.WriteLine("Friend " + friend.Name);
                                        }
                                    }
                                }
                                break;
                            }
                        case 9:
                            {
                                service.UnitOfWork.Save();
                                run = false;
                                break;
                            }
                    }
                    Console.WriteLine("\n\n\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n\n\n");
                Console.WriteLine(ex.InnerException);
                ShowUserMenu();
            }
        }
    }
}
