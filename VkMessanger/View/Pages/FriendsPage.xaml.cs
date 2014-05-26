using System.Windows.Controls;
using Vk.GUI.Dispatcher;
using VkGUI.ViewModel;
using Vk.DTO.ViewModels;

namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        GUIDispatcher dispatcher;
        private FriendsVM viewModel;

        public FriendsVM ViewModel { get { return viewModel; } set { viewModel = value; } }
        
       public FriendsPage()
        {
            dispatcher = new GUIDispatcher();
            viewModel = dispatcher.LoadFriendsViewModel();
            InitializeComponent();
        
        }

    }
}
