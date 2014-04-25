using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Vk.Interfaces.Controllers;


namespace VkGUI
{
    public static class BasePage
    {
        //TODO Подключить фабрику контроллеров.
        public static T GetService<T>(this Page value) where T : IController
        {
            throw new NotImplementedException();
        }

        
    }
}
