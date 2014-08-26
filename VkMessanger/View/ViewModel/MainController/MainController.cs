using System;
using Vk.DTO.Auth;

namespace VkGUI.ViewModel.MainController
{
    class MainController
    {
       
        
        public string AccessToken{
            get{
                if (String.IsNullOrEmpty(VkAuthInfo.AccessToken))
                {
                    return "Пожалуйста, зарегистрируйтесь";
                }
                return "Вы зарегистрованы";
            }
        }

        

    }
}
