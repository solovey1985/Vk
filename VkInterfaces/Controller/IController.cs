using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Interfaces.ViewModels;

namespace Vk.Interfaces.Controllers
{
    public interface IController
    {
        IViewModel Bind(string viewName);
    }
}
