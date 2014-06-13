using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ViewModels.ViewModels.Messages;
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

        private ObservableCollection<IMessagePage> pages;
        public ObservableCollection<IMessagePage> Pages {get { return pages; } set { pages = value; }}

        public MessageViewModel MessageVMList { get;set; }
       
        
        public MessageListViewModel()
        {
            MessageVMList=new MessageViewModel();
            pages = new ObservableCollection<IMessagePage>();
        }

        
    }
}
