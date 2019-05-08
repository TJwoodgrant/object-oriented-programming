using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nightmaher.Core;

namespace Nightmaher.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NightmaherInstance _nightmaher;

        public MainWindow()
        {
            InitializeComponent();
            _nightmaher = new NightmaherInstance();
            mainConsole.Text = _nightmaher.Output;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            mainConsole.Text = "test";
        }

        private void CommandBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
