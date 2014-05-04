using System.Windows.Controls;
using Vk.GUI.Dispatcher;
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
            GUIDispatcher dispatcher =new GUIDispatcher();
            DataContext = dispatcher.LoadData(GetType());
        }

    }
}
