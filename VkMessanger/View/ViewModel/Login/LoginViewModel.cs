using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Vk.GUI;
using Vk.GUI.View.Pages;
using VkGUI.Model;

namespace VkGUI.ViewModel.Login
{
   public class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(arg => { Login.LoginAction(); });
            Login = new LoginModel(){Login = "", Pass = ""};
        }

        public LoginModel Login { get; set; }
        public ICommand LoginCommand { get; set; }
    }
}
