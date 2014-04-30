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
      
        public UC_Message(Message message, User user)
        {
            InitializeComponent();
             var Data = new { Message = message, User = user};
          
            DataContext = Data;
        }
    }
}
