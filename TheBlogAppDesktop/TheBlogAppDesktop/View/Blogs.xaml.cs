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
    /// Interaction logic for Blogs.xaml
    /// </summary>
    public partial class Blogs : Page
    {
        CRUDManager cm = new CRUDManager();
        public Blogs()
        {
            InitializeComponent();
            //ListAllBlogs.ItemsSource = new List<string>() { "Blog1", "Blog2", "Blog3" };
            ListAllBlogs.ItemsSource = cm.getAllBlogs();
        }

        private void ListMyBlogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainFrame.Navigate(new BlogPostViewer((Blog)ListAllBlogs.SelectedItem));
        }

        private void Logout_Button_Clicked(object sender, RoutedEventArgs e)
        {
            // logout functionality
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            cm.createBlog(TextBlogName.Text, TextBlogDescription.Text);
            ListAllBlogs.ItemsSource = cm.getAllBlogs();
            ListAllBlogs.ItemsSource = cm.getAllBlogs();
        }

        private void GoToDash_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Homepage());
        }

        private void GotoPosts_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllPostsPage());
        }

        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage());
        }

        private void ShowAddBlog_Clicked(object sender, RoutedEventArgs e)
        {
            RecHider.Height = 0;
        }
    }
}
