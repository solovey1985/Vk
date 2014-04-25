using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e){
            NavigationService.Navigate(new Uri(@"View\Pages\FriendsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void GrLogin_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri(@"View\Pages\LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
