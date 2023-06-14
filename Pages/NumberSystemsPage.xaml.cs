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
            int fromSS = int.Parse(inputNumsys.Text);
            int toSS = int.Parse(outputNumsys.Text);
            string res = FromTenToSS(toSS, FromSSToTen(fromSS));
            outputNum.Text = res;
        }

        private int FromSSToTen(int fromSS)
        {
            int res = 0;
            string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string input = inputNum.Text;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                string symbol = c.ToString();
                if (alphabet.IndexOf(symbol) != -1)
                {
                    res += alphabet.IndexOf(symbol)*(int)Math.Pow(fromSS, 36 - i);
                }
            }
            return res;
        }

        private string FromTenToSS(int toSS, int input)
        {
            int inputNum = input;
            string res = "";
            while (inputNum > 0)
            {
                res += (inputNum % toSS).ToString();
                inputNum = inputNum / toSS;
            }
            return res;
        }

        
    }
}
