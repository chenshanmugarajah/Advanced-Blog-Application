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

namespace View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CRUDManager cm = new CRUDManager();
            //Register function
            string username = TextRegisterUsername.Text;
            string email = TextRegisterEmail.Text;
            string password = TextRegisterPassword.Text;

            if (username  == "")
            {
                TextRegisterUsername.Text = "Please enter a username";
                return;
            }
            if (email == "")
            {
                TextRegisterEmail.Text = "Please enter a email";
                return;
            }
            if (password == "")
            {
                TextRegisterPassword.Text = "Please enter a password";
                return;
            }

            Tuple <string, bool> response = cm.createUser(username, email, password, password);

            if (response.Item2 == false) TextRegisterUsername.Text = response.Item1;
            if (response.Item2 == true) _mainFrame.Navigate(new LoginPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage());
        }
    }
}
