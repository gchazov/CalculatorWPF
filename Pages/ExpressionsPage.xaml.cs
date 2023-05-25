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
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            input.Text += ((Button)sender).Content.ToString();
			try
			{
				output.Text = Evaluator.Calculate(input.Text).ToString();
			}
			catch (Exception ex)
			{
				output.Text = ex.Message;
			}
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
			{"pi", $"{Math.PI}"},
			{"x", "*" },
			{"÷", "/" }
			};
			if (functions.ContainsKey(function) ) 
			{ 
				realInput= functions[function];
			}
			input.Text += realInput;
			try
			{
				output.Text = Evaluator.Calculate(input.Text).ToString();
			}
			catch (Exception ex)
			{
				output.Text = ex.Message;
			}
		}

		private void EqualBtn_Click(object sender, RoutedEventArgs e )
		{
			try
			{
				output.Text = Evaluator.Calculate(input.Text).ToString();
			}
			catch (Exception ex)
			{
				output.Text = ex.Message;
			}
		}
	}
}
