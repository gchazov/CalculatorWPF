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

namespace CalcYouLate.Pages
{
    /// <summary>
    /// Логика взаимодействия для NumberSystemsPage.xaml
    /// </summary>
    public partial class NumberSystemsPage : Page
    {
        public NumberSystemsPage()
        {
            InitializeComponent();
        }

        private void InputNumSys(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (int.TryParse(inputNumsys.Text, out int res))
                NumberSystems_Result();
            else
                inputNumsys.Text = "Введите число!";
        }

        private void OutputNumSys(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (int.TryParse(outputNumsys.Text, out int res))
                NumberSystems_Result();
            else
                outputNumsys.Text = "Введите число!";
        }

        private void NumberSystems_Result()
        {
            
        }

        private void outputResult_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
