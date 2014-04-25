using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VkGUI.View;
using VkGUI.ViewModel;
using VkGUI.ViewModel.MainController;

namespace VkGUI
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainController controller =new MainController();
        Main mainWindow = new Main();

        public App(){
            mainWindow.DataContext = controller;
            mainWindow.Show();
        }
    }
}
