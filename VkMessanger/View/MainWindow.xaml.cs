using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace VkGUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
            LeftPanel.Visibility = Visibility.Collapsed;
            
        }

        void frmMainContent_Navigated(object sender, NavigationEventArgs e)
        {
            
            
        }

        private void FrmMainContentOnNavigated(object sender, NavigatingCancelEventArgs navigatingCancelEventArgs)
        {
            Frame tmp = sender as Frame;
           // string page = tmp.Source.ToString();
           // 
        }
           
        public void Navigation(object sender, RoutedEventArgs arg)
        {
            Button btn = (Button) sender;
            switch (btn.Name){
            case "btnFriendsPage":
                {
                    frmMainContent.Source = new Uri("/View/Pages/FriendsPage.xaml", UriKind.Relative);
                    
                    break;
                }
            case "btnMessagePage":
                {
                    frmMainContent.Source = new Uri("/View/Pages/MessagesPage.xaml", UriKind.Relative);
                    break;
                }
            case "btnAudioPage":
                {
                    break;
                }
            case "btnVideoPage":
                {
                    break;
                }
            case "btnGroupsPage":
                {
                    break;
                }
            case "btnLogin":
                {
                    frmMainContent.Source = new Uri("/View/Pages/LoginPage.xaml", UriKind.Relative);
                    break;
                } 
               
            }
            
        }
    }
}
