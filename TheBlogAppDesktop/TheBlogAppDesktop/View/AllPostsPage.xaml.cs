using Controller;
using Model;
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
            CRUDManager cm = new CRUDManager();
            ListAllPosts.ItemsSource = cm.getAllPosts();
        }

        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage());
        }

        private void GoToDashboard_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Homepage());
        }

        private void GoToBlogs_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Blogs());
        }

        private void ListAllPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainFrame.Navigate(new PostViewer((Post)ListAllPosts.SelectedItem));
        }
    }
}
