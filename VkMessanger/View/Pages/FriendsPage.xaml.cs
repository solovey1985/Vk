using System.Windows.Controls;
using VkGUI.ViewModel.Friends;

namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        
       public FriendsPage()
        {
            InitializeComponent();
            FriendViewModel friendViewModel = new FriendViewModel();
            DataContext = friendViewModel;
        }

    }
}
