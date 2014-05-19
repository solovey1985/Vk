using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;
using VkGUI.Model;

namespace Vk.GUI.ViewModel
{
    public class FriendsVM
    {
        FriendsOnlineVM _friendsOnlineVM = new FriendsOnlineVM();

        public FriendsOnlineVM FriendsOnlineVM
        {
            get { return _friendsOnlineVM; }
            set { _friendsOnlineVM = value; }
        }
        public FriendsVM()
        {
                
        }

        
    }
}
