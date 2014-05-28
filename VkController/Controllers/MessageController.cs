using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Models;
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
            messageService = new MessageService();
        }


        public MessageListViewModel LoadMessageListViewModel()
        {
            messageService = new MessageService();
            UserService userService = new UserService();
            
            List<Message> messageListIn = (List<Message>) messageService.messagesGet(50, Services.MessageDirection.In);
            List<User> userListIn = (List<User>)userService.usersGet(messageListIn.Select(m=>m.Uid).ToArray());
            
            List<Message> messageListOut = (List<Message>)messageService.messagesGet(50, Services.MessageDirection.Out);
            List<User> userListOut = (List<User>)userService.usersGet(messageListOut.Select(m => m.Uid).ToArray());

            

            MessageViewModel incomingMessage = new MessageViewModel() { Name = "Incoming" };
           
              foreach (Message message in messageListIn){
                incomingMessage.Messages.Add(new MessageModel { Message = message, User = userListIn.Find(u => u.Uid == message.Uid) });                                                
            }
            
            MessageViewModel outgoingMessage = new MessageViewModel() { Name = "Outgoing" };
             foreach (Message message in messageListOut){
                outgoingMessage.Messages.Add(new MessageModel { Message = message, User = userListOut.Find(u => u.Uid == message.Uid) });                                                
            }
             
            MessageListViewModel viewModel = new MessageListViewModel();
            viewModel.Pages.Add(incomingMessage);
            viewModel.Pages.Add(outgoingMessage);
            
            return viewModel;
        }
    }
}

