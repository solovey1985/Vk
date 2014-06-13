using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using ViewModels.Annotations;
using Vk.GUI.Dispatcher;
using VkGUI.ViewModel;
using Vk.DTO.ViewModels;

namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        private FriendsVM viewModel;

        public FriendsVM ViewModel { get { return viewModel; } set { viewModel = value; } }
        
       public FriendsPage()
       {     
           
           InitializeComponent();
       }


        

       
        
    }
}
