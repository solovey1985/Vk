using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.Controllers
{
    public class MessageController : VkController
    {
        private MessageService messageService;

        public MessageController()
        {

        }


        public MessageListViewModel LoadMessageListViewModel()
        {
            messageService = new MessageService();
            UserService userService = new UserService();
            
            List<Message> messageList = (List<Message>) messageService.messagesGet(50, Services.MessageDirection.In);
            List<User> userList = (List<User>)userService.usersGet(messageList.Select(m=>m.Uid).ToArray());
            
            MessageListViewModel viewModel = new MessageListViewModel();
            
            foreach (Message message in messageList){
                    viewModel.MessageVMList.Add(new MessageViewModel{Message = message, User = userList.Find(u=>u.Uid==message.Uid)});                                                
            }
            
            return viewModel;
        }
    }
}

