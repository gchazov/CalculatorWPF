using CalcYouLate.Functionality;
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
    /// Логика взаимодействия для AnglePage.xaml
    /// </summary>
    public partial class AnglePage : Page
    {
        public AnglePage()
        {
            InitializeComponent();
            DataContext = new Functionality.MeasureList();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void AngleCalc()
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
                double meters = CalcYouLate.Functionality.MeasureList.angleToDegree[from.Text] * Convert.ToDouble(input.Text);
                string result = input.Text != "0" ? (meters * CalcYouLate.Functionality.MeasureList.angleFromDegree[to.Text]).ToString() : "Недопустимый ввод!";
                output.Text = result;
            }
            catch (Exception ex)
            {
                if (input.Text == string.Empty) output.Text = "0";
                else output.Text = "Недопустимый ввод!";
            }
        }

        public void FormulaTip()
        {
            string fromText = from.Text;
            string toText = to.Text;
            if (from.Text == String.Empty || to.Text == String.Empty)
            {
                fromText = "градус";
                toText = "радиан";
                double multiple = MeasureList.angleToDegree[fromText] * MeasureList.angleFromDegree[toText];
                if (multiple > 1)
                    formula.Text = $"Для самостоятельного перевода умножьте исходную величину на {Math.Round(multiple, 2)}";
                else
                    formula.Text = $"Для самостоятельного перевода поделите исходную величину на {Math.Round(1.0 / multiple, 2)}";
            }
            else
            {
                double multiple = MeasureList.angleToDegree[fromText] * MeasureList.angleFromDegree[toText];
                if (multiple > 1)
                    formula.Text = $"Для самостоятельного перевода умножьте исходную величину на {Math.Round(multiple, 2)}";
                else
                    formula.Text = $"Для самостоятельного перевода поделите исходную величину на {Math.Round(1.0 / multiple, 2)}";
            }
        }

        private void from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AngleCalc();
            FormulaTip();
        }

        private void to_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AngleCalc();
            FormulaTip();
        }

        private void from_DropDownClosed(object sender, EventArgs e)
        {
            FormulaTip();
            AngleCalc();
        }

        private void to_DropDownClosed(object sender, EventArgs e)
        {
            AngleCalc();
            FormulaTip();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            AngleCalc();
            FormulaTip();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int indexFrom = Array.IndexOf(MeasureList.Angle, from.SelectedItem);
            from.SelectedItem = MeasureList.Angle[Array.IndexOf(MeasureList.Angle, to.SelectedItem)];
            to.SelectedItem = MeasureList.Angle[indexFrom];
            AngleCalc();
        }

    }
}
