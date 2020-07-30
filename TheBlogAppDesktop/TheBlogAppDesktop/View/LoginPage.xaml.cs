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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CRUDManager cm = new CRUDManager();
            string username = TextLoginUsername.Text;
            string password = TextLoginPassword.Text;
            if (username == "")
            {
                TextLoginUsername.Text = "Please enter a username";
                return;
            }
            if (password == "")
            {
                TextLoginPassword.Text = "Please enter a password";
                return;
            }

            Tuple <string,bool> response = cm.loginUser(username, password);

            if (response.Item2 == false) TextLoginUsername.Text = response.Item1;

            if (response.Item2 == true) _mainFrame.Navigate(new Homepage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new RegisterPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Homepage());
        }
    }
}
