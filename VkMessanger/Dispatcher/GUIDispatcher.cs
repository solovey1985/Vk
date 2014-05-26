using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;
using Vk.DTO.ViewModels;
using Vk.DTO.Controllers;

namespace Vk.GUI.Dispatcher
{
    public class GUIDispatcher
    {
        private IBaseService _service;
        private IViewModel _viewModel;
        private UserController userController;

        public IViewModel LoadData(Type t)
        {

            switch (t.Name){
                case ("MessagePage"):
                {
                    break;
                }
                case ("FriendsPage"):
                {
                    break;
                }
                case ("AudioPage"):
                {
                    break;
                }
                default:
                {
                    break;
                }
            }

            return _viewModel;
        }

        public FriendsVM LoadFriendsViewModel()
        {
           
            userController = new UserController();
           
            return userController.LoadUsersOnlineViewModel();
        }

        public MessageListViewModel LoadMessageViewModel()
        {
            MessageController messageController = new MessageController();
            return messageController.LoadMessageListViewModel();
        }
    }
}

