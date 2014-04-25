using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Controllers;
using Vk.Interfaces.ViewModels;
using Vk.DTO.Controllers;
namespace VkGUI.UserControlls
{
    /// <summary>
    /// Interaction logic for UC_Message.xaml
    /// </summary>
    public partial class UC_Message : UserControl
    {
        public UC_Message()
        {
            
            
            MessageController _controller = new MessageController() ;
            MessageListViewModel messageViewModel = _controller.Bind() as MessageListViewModel;
            InitializeComponent();
            var Data = new { Message = messageViewModel.MessageList[0] };
            DataContext = Data;

        }

        public UC_Message(Message message, User user)
        {
            InitializeComponent();
            ICommand command = new BaseCommand(s=>MessageBox.Show("sdfsdf"));
             MessageController _controller = new MessageController() ;
             var Data = new { Message = message, User = user, Command = command};
          
            DataContext = Data;
        }
    }
}
