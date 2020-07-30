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
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for BlogEditor.xaml
    /// </summary>
    public partial class BlogEditor : Window
    {
        public BlogEditor(string name)
        {
            InitializeComponent();
            this.name = name;
            LabelHeader.Content = name;
        }

        string name { get; } //Replace with Blog Object
    }
}
