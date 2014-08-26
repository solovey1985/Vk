using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VkGUI.View;
using VkGUI.View.Pages;
using VkGUI.ViewModel;
using VkGUI.ViewModel.MainController;

namespace VkGUI
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
           MainController controller;
            MainPage page;
        public App(){    
            controller =new MainController();
            page = new MainPage();
            page.DataContext = controller;
        }   
    }
}
