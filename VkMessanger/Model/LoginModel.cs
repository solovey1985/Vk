using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Auth;
using VkGUI.Annotations;

namespace Vk.GUI.View.Pages
{
    public class LoginModel: INotifyPropertyChanged
    {
        private string login;
        private string pass;
        private string loginResult;
        private bool isLoggedIn = false;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Login
        {
            get { return login; }
            set { if(login != value) {login = value; OnPropertyChanged("Login");} }
        }

        public string Pass
        {
            get { return pass; }
            set { if (pass != value) {pass = value; OnPropertyChanged("Pass");} }
        }

        public string LoginResult{
            get { return loginResult; }
            set { loginResult = value; OnPropertyChanged("LoginResult");}
        }

        public bool LoginAction(){
            VkAuthManager authManager = new VkAuthManager();
            try
            {
                authManager.GetRealAuth(this.Login, this.Pass);
                loginResult = "Success";
            }
            catch (Exception)
            {
                login = "Failed";
                return false;
            }

            if (string.IsNullOrEmpty(VkAuthInfo.AccessToken)){
                isLoggedIn = false;
                return false;
            }
            else{
                isLoggedIn = true;
                return true;    
            }
            
        }

        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
        }

    }
}
