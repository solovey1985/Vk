using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ViewModels.Models;
using ViewModels.ViewModels.Messages;
using Vk.DTO.Domain;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.ViewModels
{
    public class MessageViewModel: ViewModel, IMessagePage
    {
        public BaseCommand DeleteMessage { get; set; }
        public BaseCommand SendMessage { get; set; }
        public BaseCommand MarkAsRead { get; set; }

        public ObservableCollection<MessageModel> Messages { get; set; }
        public string Name { get; set; }

        public MessageViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
        }
    }
}
