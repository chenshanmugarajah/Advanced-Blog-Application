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
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
            CRUDManager cm = new CRUDManager();
            ListMyBlogs.ItemsSource = cm.getUserBlog(CurrentUser.Id);
            ListMyPosts.ItemsSource = cm.getUserPosts(CurrentUser.Id);
            LabelUsername.Content = CurrentUser.Username.ToUpper();
        }

        private void OpenBlogsButton_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Blogs());
        }

        private void LogoutButton_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage());
        }

        private void GotoPosts_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllPostsPage());
        }
    }
}
