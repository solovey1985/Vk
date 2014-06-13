using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Controllers;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Services;

namespace Vk.DTO.Controllers
{
    public class UserController: VkController
    {
        private MessageService messageService;

        public UserController()
        {
            _service = ServiceFactory.GetService<IMessageService>();
        }

        public FriendsVM LoadUsersOnlineViewModel()
        {
            UserService _service = new UserService();
            
            List<User> usersOnline = _service.friendsGetOnline() as List<User>;
            
            FriendsOnlineVM onlineFriends = new FriendsOnlineVM(){Name = "Online"};

            foreach (User user in usersOnline)
            {
                onlineFriends.Friends.Add(user);                   
            }

            List<User> users = _service.friendsGet() as List<User>;

            FriendsOnlineVM friends = new FriendsOnlineVM() { Name = "Friends" };

            foreach (User user in users)
            {
                friends.Friends.Add(user);
            }

            FriendsVM viewModel = new FriendsVM();
            viewModel.Pages.Add(onlineFriends);
            viewModel.Pages.Add(friends);            
            
            return viewModel;


        }

        public static FriendsVM LoadViewModelAsync()
        {
            UserService _service = new UserService();

            List<User> usersOnline = _service.friendsGetOnline() as List<User>;

            FriendsOnlineVM onlineFriends = new FriendsOnlineVM() { Name = "Online" };

            foreach (User user in usersOnline)
            {
                onlineFriends.Friends.Add(user);
            }

            List<User> users = _service.friendsGet() as List<User>;

            FriendsOnlineVM friends = new FriendsOnlineVM() { Name = "Friends" };

            foreach (User user in users)
            {
                friends.Friends.Add(user);
            }

            FriendsVM viewModel = new FriendsVM();
            viewModel.Pages.Add(onlineFriends);
            viewModel.Pages.Add(friends);

            return viewModel;
        }
    }
}
