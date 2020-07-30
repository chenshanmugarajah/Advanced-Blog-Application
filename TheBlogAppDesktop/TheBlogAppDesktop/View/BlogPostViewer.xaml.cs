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
    /// Interaction logic for BlogPostViewer.xaml
    /// </summary>
    public partial class BlogPostViewer : Page
    {
        public BlogPostViewer(Blog blog)
        {
            InitializeComponent();
            CRUDManager cm = new CRUDManager();
            ListBlogPosts.ItemsSource = cm.getBlogPosts(blog.BlogId);
            this.blog = blog;
            TextBlogName.Text = blog.Title;
            TextBlogDescription.Text = blog.Description;
        }

        public Blog blog { get; }

        private void CreatePost_Clicked(object sender, RoutedEventArgs e)
        {
            string postname = TextPostName.Text;
            string postcontent = TextPostContent.Text;

            CRUDManager cm = new CRUDManager();

            cm.createPost(blog.BlogId, postname, postcontent);
            ListBlogPosts.ItemsSource = cm.getBlogPosts(blog.BlogId);
        }

        private void UpdateBlog_Clicked(object sender, RoutedEventArgs e)
        {
            string blogname = TextBlogName.Text;
            string blogdesc = TextBlogDescription.Text;

            CRUDManager cm = new CRUDManager();

            cm.updateBlog(blog.BlogId, blogname, blogdesc);
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Blogs());
        }

        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage());
            this.NavigationService.GoBack();
        }
    }
}
