using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.DTO.Controllers;
using Vk.DTO.Auth;
using Vk.DTO.Services;

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
