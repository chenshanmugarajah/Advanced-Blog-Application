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
    /// Interaction logic for PostViewer.xaml
    /// </summary>
    public partial class PostViewer : Page
    {
        public PostViewer(Post post1)
        {
            InitializeComponent();
            TextPostTitle.Text = post1.Title;
            TextPostContent.Text = post1.Content;

            CRUDManager cm = new CRUDManager();
            ListComments.ItemsSource = cm.getPostComments(post1.PostId);
            this.post = post1;
            postsLikes.Text = post.Likes.ToString();
        }

        public Post post { get; }

        private void GoToDash_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Homepage());
        }

        private void GotoPosts_Clicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Blogs());
        }

        private void PostComment_Clicked(object sender, RoutedEventArgs e)
        {
            CRUDManager cm = new CRUDManager();
            cm.createComment(post.PostId, PostComment.Text);
            ListComments.ItemsSource = cm.getPostComments(post.PostId);
        }

        private void EditPost_Clicked(object sender, RoutedEventArgs e)
        {
            CRUDManager cm = new CRUDManager();
            cm.updatePost(post.PostId, TextPostContent.Text);
        }

        private void LikePost_Clicked(object sender, RoutedEventArgs e)
        {
            CRUDManager cm = new CRUDManager();
            cm.likePost(post.PostId);
            postsLikes.Text = (post.Likes + 1).ToString();
        }
    }
}
