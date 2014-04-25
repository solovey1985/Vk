using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkGUI.Model;

namespace VkGUI.ViewModel.Friends
{
    class FriendViewModel
    {
        public FriendViewModel()
        {
            Friend = new FriendModel(){Name = "Andrew", Surname = "Solovienko"};
        }

        public  FriendModel Friend { get; set; }
    }
}
