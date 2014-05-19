using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VkGUI.Model;
using  Vk.DTO.Controllers;
namespace Vk.GUI.View.Pages
{
    /// <summary>
    /// Interaction logic for UC_Friend.xaml
    /// </summary>
    public partial class UC_Friend : UserControl
    {
        private UserController _controller;
        public UC_Friend()
        {
            InitializeComponent();
            _controller = new UserController();
            //Связываем с ViewModel FriendsOnlineVM
            DataContext = _controller.LoadUsersOnlineViewModel();
        }
        public UC_Friend(FriendModel friend)
        {
            InitializeComponent();
           
            
        }
    }
}
