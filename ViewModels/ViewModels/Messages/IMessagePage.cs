using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ViewModels.Models;
using Vk;

namespace ViewModels.ViewModels.Messages
{
    public interface IMessagePage
    {
        ObservableCollection<MessageModel> Messages { get; set; }
        string Name { get; }
       

    }
}
