using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Vk.DTO.Domain;
using System.Text;
using System.Windows.Input;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.ViewModels
{
    public class MessageListViewModel: ViewModel
    {

        public BaseCommand GetMessagesCommand;
        public BaseCommand MarkAsReadCommand;
        public BaseCommand DeleteMessageCommand;
        public BaseCommand SendMessageCommand;

        public List<Message> MessageList { get; set; }
        public List<User> UserList { get; set;}
        public string Message { get; set; }
        
        public MessageListViewModel()
        {
            
        }
        
    }
}
