using System.Collections.Generic;
using System.Linq;
using ViewModels.Models;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;

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
            foreach (var message in messageListIn){
               incomingMessage.Messages.Add(new MessageModel{
                Message = message,
                User = userListIn.Find(u => u.Uid == message.Uid)
            }); 
            }
           
            MessageViewModel outgoingMessage = new MessageViewModel() { Name = "Outgoing" };
            
            foreach (var message in messageListOut){
                outgoingMessage.Messages.Add(new MessageModel{
                    Message = message,
                    User = userListOut.Find(u => u.Uid == message.Uid)
                });
            }
            
            MessageListViewModel viewModel = new MessageListViewModel();
            viewModel.Pages.Add(incomingMessage);
            viewModel.Pages.Add(outgoingMessage);
            
            return viewModel;
        }

        public MessageListViewModel MarkAsReadMessage(string MessageIds)
        {
            logger.Info("Marks message as Read: " + MessageIds);
            return LoadMessageListViewModel();
        }
    }
}

