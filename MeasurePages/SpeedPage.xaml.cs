﻿using CalcYouLate.Functionality;
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
    /// Логика взаимодействия для SpeedPage.xaml
    /// </summary>
    public partial class SpeedPage : Page
    {
        public SpeedPage()
        {
            InitializeComponent();
            DataContext = new Functionality.MeasureList();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void SpeedCalc()
        {
            string inputText = input.Text;
            if (inputText == "") inputText += "0";
            try
            {
                inputText = Evaluator.MakeCalculation(inputText).ToString();
            }
            catch (Exception)
            {
                output.Text = "Недопустимый ввод!";
                return;
            }
            if (from.Text == to.Text) output.Text = inputText;
            try
            {
                if (from.Text == to.Text)
                {
                    if (double.TryParse(inputText, out double res))
                        output.Text = inputText;
                    else output.Text = "Недопустимый ввод!";
                    return;
                }
                double meters = CalcYouLate.Functionality.MeasureList.speedToKmPh[from.Text] * Convert.ToDouble(inputText);
                string result = inputText != "0" ? (meters * CalcYouLate.Functionality.MeasureList.speedFromKmPh[to.Text]).ToString() : "0";
                output.Text = result;
            }
            catch (Exception)
            {
                if (inputText == string.Empty) output.Text = "0";
                else output.Text = "Недопустимый ввод!";
            }
        }

        public void FormulaTip()
        {
            if (from.Text == String.Empty || to.Text == String.Empty)
                FormulaFunc("метр/сек", "километр/час");
            else
                FormulaFunc(from.Text, to.Text);
        }

        public void FormulaFunc(string from, string to)
        {
            double multiple = MeasureList.speedFromKmPh[from] * MeasureList.speedToKmPh[to];
            if (multiple > 1)
                formula.Text = $"Для самостоятельного перевода поделите исходную величину на {Math.Round(multiple, 2)}";
            else if (multiple == 1)
                formula.Text = $"Выражение величины является тождеством";
            else
                formula.Text = $"Для самостоятельного перевода умножьте исходную величину на {Math.Round(1.0 / multiple, 2)}";
        }

        private void from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeedCalc();
            FormulaTip();
        }

        private void to_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeedCalc();
            FormulaTip();
        }

        private void to_DropDownClosed(object sender, EventArgs e)
        {
            SpeedCalc();
            FormulaTip();
        }

        private void from_DropDownClosed(object sender, EventArgs e)
        {
            SpeedCalc();
            FormulaTip();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            SpeedCalc();
            FormulaTip();
        }
    }
}
