﻿using System;
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

		public static string DecToSystem(int inputNum, int newSystem)
		{
			string result = "";
			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			while (inputNum != 0)
			{
				if ((inputNum % newSystem) < 10)
					result = inputNum % newSystem + result;
				else
				{
					string temp = alphabet[inputNum % newSystem-10].ToString();

					result = temp + result;
				}

				inputNum /= newSystem;
			}

			return result;
		}

		public static int SystemToDec(string inputNum, int fromSystem)
		{
			int result = 0;
			int count = inputNum.Length - 1;
			for (int i = 0; i < inputNum.Length; i++)
			{
				int temp = 0;
				switch (inputNum[i])
				{
					case 'A': temp = 10; break;
					case 'B': temp = 11; break;
					case 'C': temp = 12; break;
					case 'D': temp = 13; break;
					case 'E': temp = 14; break;
					case 'F': temp = 15; break;
					case 'G': temp = 15; break;
					default: temp = -48 + (int) inputNum[i]; break; // -48 because of ASCII
				}

				result += temp * (int) (Math.Pow(fromSystem, count));
				count--;
			}

			return result;
		}

		public static bool IsSuitableSystem(string inputNum, int system)
		{
			char[] alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			char[] sysAlphabet = alphabet.Take(system).ToArray();
			foreach (char letter in inputNum)
			{
				if (!sysAlphabet.Contains(letter))
				{
					return false;
				}
			}
			return true;
		}


        private void ParametersChanged(object sender, RoutedEventArgs e)
        {
            int fromSystem, toSystem;
            string fromSystemNum;

			try
            {
                fromSystemNum = inputNum.Text;
                if (inputNumsys is null)
                {
					inputNumsys = new TextBox();
					outputNumsys = new TextBox();
				}
                fromSystem = Convert.ToInt32(inputNumsys.Text);
				toSystem = Convert.ToInt32(outputNumsys.Text);
			}
            catch
            {
                return;
            }
			if (IsSuitableSystem(fromSystemNum, fromSystem))
			{
				string toNum = DecToSystem(SystemToDec(fromSystemNum, fromSystem), toSystem);
				outputNum.Text = toNum;
			}
			else
			{
				outputNum.Text = "Число не в заданной системе";
			}
            
        }
    }
}
