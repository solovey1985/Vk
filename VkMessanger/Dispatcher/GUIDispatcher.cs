using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Vk.DTO.Domain;
using Vk.Interfaces.Services;
using Vk.Interfaces.ViewModels;
using Vk.DTO.ViewModels;
using Vk.DTO.Controllers;
using VkGUI.View.Pages;

namespace Vk.GUI.Dispatcher
{
    public class GUIDispatcher
    {
        private IBaseService _service;
        private IViewModel _viewModel;
        private Page page;
        private UserController userController;

        public async Task<IViewModel> LoadData(Type t)
        {

            switch (t.Name){
                case ("MessagesPage"):
                {
                    _viewModel = await Task.Run(() => LoadMessageViewModel());
                    break;
                }
                case ("FriendsPage"):
                {
                 _viewModel =   await Task.Run(() => LoadFriendsViewModel());
                 break;
                }
                case ("AudioPage"):
                {
                    break;
                }
                default:
                {
                    break;
                }
            }

            return _viewModel;
        }

        public FriendsVM LoadFriendsViewModel()
        {
            return  new UserController().LoadUsersOnlineViewModel();
        }

    

        public MessageListViewModel LoadMessageViewModel()
        {
            return new MessageController().LoadMessageListViewModel();
        }

        internal Page LoadPage(string pageName)
        {
            
            switch (pageName)
            {
            case ("MessagePage"):
            {
                page = new MessagesPage();
                page.Loaded += page_Loaded;
                break;
                
            }
            case ("FriendsPage"):
            {
                page = new FriendsPage();
                page.Loaded+=page_Loaded;
                break;
            }
            case ("AudioPage"):
            {
                break;
            }
            case ("LoginPage"):
            {    page = new LoginPage();
                break;
            }
            default:
            {
                page = new MainPage();
                break;
            }
        }

            return page;
        }

        private async void page_Loaded(object sender, RoutedEventArgs e)
        {
            Page p = sender as Page;
            string t = sender.GetType().Name;
           
            p.DataContext = await LoadData(sender.GetType());
        }
    }
}

