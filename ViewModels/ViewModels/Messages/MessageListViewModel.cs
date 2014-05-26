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

        public ObservableCollection<MessageViewModel> MessageVMList { get;set; }
       
        
        public MessageListViewModel()
        {
            MessageVMList = new ObservableCollection<MessageViewModel>();
        }
        
    }
}
