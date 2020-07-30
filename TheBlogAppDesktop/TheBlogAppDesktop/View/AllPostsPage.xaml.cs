using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for AllPostsPage.xaml
    /// </summary>
    public partial class AllPostsPage : Page
    {
        public AllPostsPage()
        {
            InitializeComponent();
        }

        private void GoToBash_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Homepage());
        }

        private void GotoPosts_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Blogs());
        }

        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage());
        }
    }
}
