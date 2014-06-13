using System.Collections.Generic;
using System.Linq;
using Vk.DTO.Controllers;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;
using Vk.GUI.Dispatcher;
using Vk.Interfaces.Domain;
using Vk.GUI.UserControlls;
using VkGUI.ViewModel.MainController;


namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for MessagesPage.xaml
    /// </summary>
    public partial class MessagesPage
    {
        private MessageListViewModel _viewModel;
        public MessageListViewModel MessageListViewModel { get { return _viewModel; } set { _viewModel = value; } }
        public MessagesPage(){
          InitializeComponent();
          }
    }
}
