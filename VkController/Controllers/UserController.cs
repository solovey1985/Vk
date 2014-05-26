using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Controllers;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;

namespace Vk.DTO.Controllers
{
    public class UserController: VkController
    {
        private MessageService messageService;

        public FriendsVM LoadUsersOnlineViewModel()
        {
           UserService _service = new UserService();
            

           

            List<User> users = _service.friendsGetOnline() as List<User>;

            FriendsVM viewModel = new FriendsVM();

            foreach (User user in users){
                viewModel.FriendsOnlineVM.UsersOnline.Add(user);    
            }
            
           
            
            return viewModel;


        }
    }
}
