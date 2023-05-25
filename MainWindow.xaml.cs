using CalcYouLate.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace CalcYouLate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            navFrame.Navigate((sidebar.SelectedItem as NavButton).NavLink);
        }

        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Minimize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void HelpButton(object sender, EventArgs e)
        {
            string path;
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Functionality\Help\Helpidr.chm";
            Process.Start(path);
        }

        private void OpenHelpidr(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                string path;
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Functionality\Help\Helpidr.chm";
                Process.Start(path);
            }
        }
    }
}
