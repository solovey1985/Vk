using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vk.DTO.Domain;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.ViewModels
{
    public class MessageViewModel: ViewModel
    {
        public BaseCommand DeleteMessage { get; set; }
        public BaseCommand SendMessage { get; set; }
        public BaseCommand MarkAsRead { get; set; }

        public Message Message { get; set; }
        public User User { get; set; }
    }
}
