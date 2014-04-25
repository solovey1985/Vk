using System.Collections.Generic;
using System.Linq;
using Vk.DTO.Controllers;
using Vk.DTO.Domain;
using Vk.DTO.Services;
using Vk.DTO.ViewModels;
using Vk.Interfaces.Domain;
using VkGUI.UserControlls;
using VkGUI.ViewModel.MainController;


namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for MessagesPage.xaml
    /// </summary>
    public partial class MessagesPage
    {
        public MessagesPage(){
           InitializeComponent();
            MessageController _controller = new MessageController();
            MessageListViewModel viewModel = _controller.Bind() as MessageListViewModel;
            
            foreach (Message message in viewModel.MessageList){
                
                UC_Message messageView = new UC_Message(message, viewModel.UserList.Find(x=>x.Uid==message.Uid)); 
                
                messageContainer.Children.Add(messageView);
            }
            

        }
    }
}
