using System.Windows.Input;
using Vk.GUI.View.Pages;

namespace VkGUI.ViewModel.Login
{
   public class LoginViewModel
    {
        public LoginViewModel()
        {
            Login = new LoginModel();  
            LoginCommand = new Command(arg => { Login.LoginAction(); });
        }

        public LoginModel Login { get; set; }
        public ICommand LoginCommand { get; set; }
    }
}
