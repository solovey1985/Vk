using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Vk.GUI.Dispatcher;

namespace VkGUI.View.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(){
           InitializeComponent();
        }

        private async void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {

            MouseEventArgs m = e as MouseEventArgs;
            GUIDispatcher dispatcher = new GUIDispatcher();
            FrameworkElement source = sender as FrameworkElement;

            switch (source.Name){

            case "grFriends":
                {NavigationService.Navigate(dispatcher.LoadPage("FriendsPage")); break;}

            case "grMessages":
                {
                    NavigationService.Navigate(dispatcher.LoadPage("MessagePage")); break;
                }
            case "grAudio":
                    {
                        NavigationService.Navigate(dispatcher.LoadPage("AudioPage")); break;
                }
            case "grLogin":
                    {
                        NavigationService.Navigate(dispatcher.LoadPage("LoginPage")); break;
                }
                default:
                {
                    break;
                }


            }

        }
    }
}
