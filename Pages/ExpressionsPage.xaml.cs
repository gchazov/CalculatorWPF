using CalcYouLate.Functionality.Expressions;
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
    /// Логика взаимодействия для ExpressionsPage.xaml
    /// </summary>
    public partial class ExpressionsPage : Page
    {
        public ExpressionsPage()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, input);
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            input.Text += ((Button)sender).Content.ToString();
			//try
			//{
			//	output.Text = Evaluator.MakeCalculation(input.Text).ToString();
			//}
			//catch (Exception ex)
			//{
			//	output.Text = ex.Message;
			//}
		}

		private void FuncBtn_Click(object sender, RoutedEventArgs e)
		{
            string function = ((Button)sender).Content.ToString();
            string realInput = function;
            Dictionary<string, string> functions = new Dictionary<string, string>()
			{
			{"х²", "^2"},
			{"n!",  "!"},
			{ "log(x)", "log("},
			{"√х", "sqrt("},
			{"sin(x)", "sin("},
			{"cos(x)", "cos("},
			{"tg(x)", "tg("},
			{"ctg(x)", "ctg("},
			{ "1/x", "^(-1)"},
			{"|x|", "abs("},
			{"ln(x)", "ln("},
			{"π", $"π"},
			{"e", "e" },
			{"x", "*" },
			{"÷", "/" },
			{"xʸ", "^" }
			};
			if (functions.ContainsKey(function) ) 
			{ 
				realInput= functions[function];
			}
			input.Text += realInput;
            FocusManager.SetFocusedElement(this, input);
            input.ScrollToEnd();
            //try
            //{
            //	output.Text = Evaluator.MakeCalculation(input.Text).ToString();
            //}
            //catch (Exception ex)
            //{
            //	output.Text = ex.Message;
            //}
        }

		private void EqualBtn_Click(object sender, RoutedEventArgs e )
		{
			try
			{
				output.Text = Evaluator.MakeCalculation(input.Text).ToString();
			}
			catch (Exception ex)
			{
				output.Text = ex.Message;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			input.Text = String.Empty;
            output.Text = String.Empty;
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
			input.Text += ",";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
			if (input.Text.Length > 0)
			{
				input.Text = input.Text.Remove(input.Text.Length - 1, 1);
			}
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                output.Text = Evaluator.MakeCalculation(input.Text).ToString();
            }
            catch (Exception ex)
            {
                output.Text = ex.Message;
            }
        }
    }
}
