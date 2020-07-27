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
    /// Interaction logic for BlueView.xaml
    /// </summary>
    public partial class BlueView : UserControl
    {
        CRUDManager cm = new CRUDManager();

        public BlueView()
        {
            InitializeComponent();
            try
            {
                DeleteMeLabel.Content = cm.getCurrentUser().Username;
            } catch (Exception e)
            {
                DeleteMeLabel.Content = "Not logged in";
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            cm.logoutUser();
        }
    }
}
