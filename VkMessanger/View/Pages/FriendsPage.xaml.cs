using System.Windows.Controls;
using Vk.GUI.ViewModel;
using VkGUI.ViewModel;


namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        private FriendsVM viewModel;

        public FriendsVM ViewModel { get { return viewModel; } set { viewModel = value; } }
        
       public FriendsPage()
        {
            viewModel = new FriendsVM();
            InitializeComponent();
        
        }

    }
}
