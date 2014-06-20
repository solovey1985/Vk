using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ViewModels.ViewModels.Users;

namespace Vk.DTO.ViewModels
{
    public class FriendsVM: ViewModel
    {
        private FriendsOnlineVM _friendsOnlineVM;

        private ObservableCollection<IFriendsPage> pages;
        public ObservableCollection<IFriendsPage> Pages{get { return pages; } set { pages = value; }}


        public FriendsOnlineVM FriendsOnlineVM
        {
            get { return _friendsOnlineVM; }
            set { _friendsOnlineVM = value; }
        }
        public FriendsVM()
        {
            pages=new ObservableCollection<IFriendsPage>();
        }

    }
}
