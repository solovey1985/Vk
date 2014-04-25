using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Interfaces.Api;
using Vk.Interfaces.ViewModels;
using Vk.Interfaces.ViewModels;


namespace Vk.Interfaces.Services
{
    public interface IBaseService{
        IVkApi api { get; set; }
        IViewModel viewModel { get; set; }

        IViewModel GetViewModel();

        bool Authorize(string login, string pass);


    }
}
