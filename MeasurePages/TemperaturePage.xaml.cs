using CalcYouLate.Functionality;
using CalcYouLate.Functionality.Expressions;
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
    /// Логика взаимодействия для TemperaturePage.xaml
    /// </summary>
    public partial class TemperaturePage : Page
    {
        public TemperaturePage()
        {
            InitializeComponent();
            DataContext = new Functionality.MeasureList();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void TemperatureCalc()
        {
            string textForCalculating = input.Text;
            if (textForCalculating == "") textForCalculating += "Пустой ввод!";
            try
            {
                textForCalculating = Evaluator.MakeCalculation(textForCalculating).ToString();
            }
            catch (Exception)
            {
                output.Text = "Недопустимый ввод!";
                return;
            }
            if (input.Text == string.Empty) textForCalculating = "Пустой ввод!";
            else textForCalculating = input.Text;
            textForCalculating = textForCalculating.Replace(".", ",");
            try
            {
                //ДЛЯ ПЕРЕВОДА ИЗ ГРАДУСОВ ЦЕЛЬСИЯ
                if (from.Text == "градус Цельсия" && to.Text == "градус Цельсия")
                {
                    output.Text = input.Text;
                    FormulaTip($"Выражение величины является тождеством");
                }
                else if (from.Text == "градус Цельсия" && to.Text == "градус Фаренгейта")
                {
                    output.Text = (Convert.ToInt32(textForCalculating) * 1.8 + 32).ToString();
                    FormulaTip("Для перевода градусов Цельсия в Фаренгейта умножьте исходную величину на 1.8 и прибавьте 32");
                }
                else if (from.Text == "градус Цельсия" && to.Text == "градус Кельвина")
                {
                    output.Text = (Convert.ToInt32(textForCalculating)  + 273.15).ToString();
                    FormulaTip($"Для перевода градусов Цельсия в Кельвина прибавьте к исходной величине 273,15");
                }
                else if (from.Text == "градус Цельсия" && to.Text == "градус Реомюра")
                {
                    output.Text = (Convert.ToInt32(textForCalculating) * 0.8).ToString();
                    FormulaTip($"Для перевода градусов Цельсия в Реомюра умножьте исходную величину на 0,8");
                }

                //ДЛЯ ПЕРЕВОДА ИЗ ГРАДУСОВ ФАРЕНГЕЙТА
                if (from.Text == "градус Фаренгейта" && to.Text == "градус Фаренгейта")
                {
                    output.Text = input.Text;
                    FormulaTip($"Выражение величины является тождеством");
                }
                else if (from.Text == "градус Фаренгейта" && to.Text == "градус Цельсия")
                {
                    output.Text = ((Convert.ToInt32(textForCalculating) - 32) * 5 / 9).ToString();
                    FormulaTip("Для перевода градусов Фаренгейта в Цельсия отнимите от исходной величины 32 и поделите на 1,8");
                }
                else if (from.Text == "градус Фаренгейта" && to.Text == "градус Кельвина")
                {
                    output.Text = ((Convert.ToInt32(textForCalculating) + 459.67) * 5 / 9).ToString();
                    FormulaTip($"Для перевода градусов Фаренгейта в Кельвина прибавьте к исходной величине 459,67 и поделите на 1,8");
                }
                else if (from.Text == "градус Фаренгейта" && to.Text == "градус Реомюра")
                {
                    output.Text = (Convert.ToInt32(textForCalculating) * 9 / 4).ToString();
                    FormulaTip($"Для перевода градусов Фаренгейта в Реомюра умножьте исходную величину на 9/4");
                }

                //ДЛЯ ПЕРЕВОДА ИЗ ГРАДУСОВ КЕЛЬВИНА
                if (from.Text == "градус Кельвина" && to.Text == "градус Кельвина")
                {
                    output.Text = input.Text;
                    FormulaTip($"Выражение величины является тождеством");
                }
                else if (from.Text == "градус Кельвина" && to.Text == "градус Цельсия")
                {
                    output.Text = (Convert.ToInt32(textForCalculating) - 273.15).ToString();
                    FormulaTip("Для перевода градусов Кельвина в Цельсия отнимите от исходной величины 273,15");
                }
                else if (from.Text == "градус Кельвина" && to.Text == "градус Фаренгейта")
                {
                    output.Text = ((Convert.ToInt32(textForCalculating) * 1.8) - 459.67).ToString();
                    FormulaTip($"Для перевода градусов Кельвина в Фаренгейта умножьте исходную величина на 1.8 и отнимите 459,67");
                }
                else if (from.Text == "градус Кельвина" && to.Text == "градус Реомюра")
                {
                    output.Text = ((Convert.ToInt32(textForCalculating) * 0.8) - 218).ToString();
                    FormulaTip($"Для перевода градусов Кельвина в Реомюра умножьте исходную величину на 0,8 и отнимите 218");
                }

                //ДЛЯ ПЕРЕВОДА ИЗ ГРАДУСОВ РЕОМЮРА
                if (from.Text == "градус Реомюра" && to.Text == "градус Реомюра")
                {
                    output.Text = input.Text;
                    FormulaTip($"Выражение величины является тождеством");
                }
                else if (from.Text == "градус Реомюра" && to.Text == "градус Цельсия")
                {
                    output.Text = (Convert.ToInt32(textForCalculating) * 1.25).ToString();
                    FormulaTip("Для перевода градусов Реомюра в Цельсия умножьте исходную величину на 1.25");
                }
                else if (from.Text == "градус Реомюра" && to.Text == "градус Фаренгейта")
                {
                    output.Text = ((Convert.ToInt32(textForCalculating) * 2.25) + 32).ToString();
                    FormulaTip($"Для перевода градусов Реомюра в Фаренгейта умножьте исходную величина на 2.25 и отнимите 32");
                }
                else if (from.Text == "градус Реомюра" && to.Text == "градус Кельвина")
                {
                    output.Text = ((Convert.ToInt32(textForCalculating) * 1.25) + 273.15).ToString();
                    FormulaTip($"Для перевода градусов Реомюра в Кельвина умножьте исходную величину на 1.25 и прибавьте 273.15");
                }


            }
            catch (Exception)
            {
                if (input.Text == string.Empty) output.Text = "0";
                else output.Text = "Недопустимый ввод!";
            }
        }

        void FormulaTip(string info)
        {
            formula.Text = info;
        }

        private void from_DropDownClosed(object sender, EventArgs e)
        {
            TemperatureCalc();
        }

        private void from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TemperatureCalc();
        }

        private void to_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TemperatureCalc();
        }

        private void to_DropDownClosed(object sender, EventArgs e)
        {
            TemperatureCalc();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            TemperatureCalc();
        }
    }
}
