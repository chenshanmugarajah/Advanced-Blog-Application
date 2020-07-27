using Controller;
using Database;
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

namespace View.Views
{
    /// <summary>
    /// Interaction logic for ThreadView.xaml
    /// </summary>
    public partial class ThreadView : UserControl
    {
        CRUDManager cm = new CRUDManager();

        public ThreadView()
        {
            InitializeComponent();
            ListThreads();
        }

        public void ListThreads()
        {
            ListBoxThread.ItemsSource = cm.getAllThreads();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string owner = cm.getCurrentUser().Username;
            string name = TextThreadName.Text;
            string desc = TextThreadDescription.Text;

            TextThreadName.Text = cm.createThread(name, desc, owner);
            ListBoxThread.ItemsSource = cm.getAllThreads();
        }
    }
}
