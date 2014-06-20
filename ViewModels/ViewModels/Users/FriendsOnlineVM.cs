using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ViewModels.ViewModels.Users;
using Vk.DTO.Domain;
using Vk.DTO.ViewModels;

namespace Vk.DTO.ViewModels
{
    public class FriendsOnlineVM : ViewModel, IFriendsPage
    {
        public BaseCommand SendMessage { get; set; }
        
        public ObservableCollection<User> Friends { get; set; }
        public string Name { get; set; }
        #region .ctor

        public FriendsOnlineVM()
        {
                Friends = new ObservableCollection<User>();
        }
        #endregion
    }
}
