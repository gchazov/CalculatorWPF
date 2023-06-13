using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CalcYouLate.MeasurePages
{
    /// <summary>
    /// Логика взаимодействия для TimePage.xaml
    /// </summary>
    public partial class TimePage : Page
    {
        public TimePage()
        {
            InitializeComponent();
            DataContext = new Functionality.MeasureList();
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void TimeCalc()
        {
            if (from.Text == to.Text) output.Text = input.Text;
            try
            {
                if (from.Text == to.Text)
                {
                    if (double.TryParse(input.Text, out double res))
                        output.Text = input.Text;
                    else output.Text = "Недопустимый ввод!";
                    return;
                }
                double meters = CalcYouLate.Functionality.MeasureList.timeToSec[from.Text] * Convert.ToDouble(input.Text);
                string result = input.Text != "0" ? (meters * CalcYouLate.Functionality.MeasureList.timeFromSec[to.Text]).ToString() : "Недопустимый ввод!";
                output.Text = result;
            }
            catch (Exception ex)
            {
                if (input.Text == string.Empty) output.Text = "0";
                else output.Text = "Недопустимый ввод!";
            }
        }

        private void from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeCalc();
        }

        private void to_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeCalc();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            TimeCalc();
        }

        private void from_DropDownClosed(object sender, EventArgs e)
        {
            TimeCalc();
        }

        private void to_DropDownClosed(object sender, EventArgs e)
        {
            TimeCalc();
        }
    }
}
