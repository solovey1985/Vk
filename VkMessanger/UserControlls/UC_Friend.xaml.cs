using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VkGUI.Model;

namespace VkGUI.UserControlls
{
    /// <summary>
    /// Interaction logic for UC_Friend.xaml
    /// </summary>
    public partial class UC_Friend : UserControl
    {
        public UC_Friend(FriendModel friend)
        {
            InitializeComponent();
            Surname.Text = friend.Surname;
            Firstname.Text = friend.Name;
            
        }
    }
}
