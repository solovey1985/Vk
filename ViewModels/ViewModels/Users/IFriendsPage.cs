using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Vk.DTO.Domain;

namespace ViewModels.ViewModels.Users
{
    public interface IFriendsPage
    {
        ObservableCollection<User>  Friends { get; set; }
        string Name { get; set; }
    }
}
