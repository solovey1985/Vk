using Vk.DTO.ViewModels;

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
