using Controller;
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
    /// Interaction logic for RedView.xaml
    /// </summary>
    ///

    public partial class RedView : UserControl
    {
        CRUDManager cm = new CRUDManager();

        public RedView()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsername.Text;
            string email = RegisterEmail.Text;
            string password = RegisterPassword.Text;
            string passwordC = RegisterCPassword.Text;

            RegisterUsername.Text = cm.createUser(username, email, password, passwordC);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsername.Text;
            string password = LoginPassword.Text;

            LoginUsername.Text = cm.loginUser(username, password);
        }
    }
}
