using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Domain;

namespace Vk.GUI.ViewModel
{
    public class FriendsOnlineVM
    {
           public IObservable<User>  UsersOnline { get; set; }
    }
}
