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

        public FriendsOnlineVM LoadUsersOnlineViewModel()
        {
           UserService _service = new UserService();


           

            List<User> users = _service.friendsGetOnline() as List<User>;

            FriendsOnlineVM viewModel = new FriendsOnlineVM();

            foreach (User user in users){
                viewModel.UsersOnline.Add(user);    
            }
             
            
            return viewModel;


        }
    }
}
