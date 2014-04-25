using System;
using log4net;
using Vk.DTO.Domain;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Api;
using Vk.DTO.Controllers;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.Test
{
   
    class Program
    {
        private static IVkApi api;
        private  static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private static MessageController _controller;
        
        static void Main(string[] args)
        {
            try{

                _controller = new MessageController();
                
                if (!_controller.IsAuthorized)
                _controller.Login("solovey1985@ukr.net", "Dhjnvytyjub1");

                MessageListViewModel viewModel = _controller.Bind() as MessageListViewModel;
                
                foreach (Message message in viewModel.MessageList){
                    Console.WriteLine("{0}", message.Body);
                }
                Console.WriteLine(viewModel.ViewName);
            }
            catch (Exception){
                
                throw;
            }
            Console.ReadLine();
        }
    }
}
