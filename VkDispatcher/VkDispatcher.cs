using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Interfaces.Api;
using Vk.Interfaces.Controllers;
using Vk.Interfaces.Services;
using Vk.Interfaces.Domain;
using Vk.Interfaces.DAL;
using Vk.Interfaces.ViewModels;



namespace Vk.Dispatcher
{
    public class VkDispatcher
    {
        private IVkApi api;
        private IController controller;
        private IBaseService service;
    }
}
