using System.Windows.Controls;
using Vk.GUI.View.Pages;
using VkGUI.ViewModel.Login;

namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private LoginViewModel viewModel;

        public LoginViewModel ViewModel { get { return viewModel; } set { viewModel = value; } }

        public LoginPage()
        {
            InitializeComponent();
            UC_Login uc_Login = new UC_Login();
            uc_Login.DataContext = new LoginViewModel();
            UC_Parent.Content = uc_Login;

        }
    }
}
