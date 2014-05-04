using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;

namespace Vk.GUI.Dispatcher
{
    public class GUIDispatcher
    {
        private IBaseService _service;
        private IViewModel _viewModel;

        public IViewModel LoadData(Type t){

            switch (t.Name)
            {
                case ("MessagePage"):
                {
                    break;
                }
                case ("FriendsPage"):
                {
                    break;
                }
                case ("AudioPage"):
                {
                    break;
                }
                default:
                {
                  break;  
                }
            }

            return _viewModel;
        }
    }
}
