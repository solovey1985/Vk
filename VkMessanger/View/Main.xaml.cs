using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using VkGUI.ViewModel.MainController;

namespace VkGUI.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        private MainController appController;
        public Main()
        {
            InitializeComponent();
           appController = new MainController();
            DataContext = appController;
        }

     }
}
