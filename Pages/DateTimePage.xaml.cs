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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcYouLate.Pages
{


	/// <summary>
	/// Логика взаимодействия для DateTimePage.xaml
	/// </summary>
	public partial class DateTimePage : Page
	{

		public DateTimePage()
		{
			InitializeComponent();
			from.SelectedDate = DateTime.Today;
			to.SelectedDate = DateTime.Today;
		}

		private int[] GetDelta (DateTime fromDate, DateTime toDate)
		{
			int Months = (toDate.Year - fromDate.Year) * 12 + (toDate.Month - fromDate.Month);

			// Если день первой даты меньше дня второй даты, то вычитаем один месяц
			if (toDate.Day < fromDate.Day && toDate > fromDate)
			{
				--Months;
			}

			if (toDate.Day > fromDate.Day && toDate < fromDate)
			{
				++Months;
			}

			int Years = Months / 12;

			int Days = (toDate - fromDate).Days;

			int Weeks = Days / 7;

			return new[] {Days, Weeks, Months, Years};
		}


		private void DateTime_Result(object sender,
	SelectionChangedEventArgs e)
		{
			if (to.SelectedDate is null)
			{
				to.SelectedDate = DateTime.Today;
			}
			if (from.SelectedDate is null)
			{
				from.SelectedDate = DateTime.Today;
			}

			int[] delta = GetDelta(from.SelectedDate.Value, to.SelectedDate.Value);
			int Days = delta[0];
			int Weeks = delta[1];
			int Months = delta[2];
			int Years = delta[3];


			string yearsText = "Лет";
			if (Years < 10 || Years > 20)
			{
				if (Years % 10 == 1)
				{
					yearsText = "Год";
				}
				else if (Years % 10 > 1 && Years % 10 < 5)
				{
					yearsText = "Года";
				}
			}


			string monthText = "Месяцев";
			if (Months < 10 || Months > 20)
			{
				if (Months % 10 == 1)
				{
					monthText = "Месяц";
				}
				else if (Months % 10 > 1 && Months % 10 < 5)
				{
					monthText = "Месяца";
				}
			}

            string weekText = "Недель";
            if (Weeks < 10 || Weeks > 20)
            {
                if (Weeks % 10 == 1)
                {
                    weekText = "Неделя";
                }
                else if (Weeks % 10 > 1 && Weeks % 10 < 5)
                {
                    weekText = "Недели";
                }
            }


            string daysText = "Дней";
			if (Days < 10 || Days > 20)
			{
				if (Days % 10 == 1)
				{
					daysText = "День";

				}
				else if (Days % 10 > 1 && Days % 10 < 5)
				{
					daysText = "Дня";
				}
			}

			
			monthsBox.Text = Months.ToString();
			yearsBox.Text = Years.ToString();
			weaksBox.Text = (Days / 7).ToString();
			daysBox.Text = Days.ToString();

			daysBox.SelectionStart = daysBox.Text.Length;
			weaksBox.SelectionStart = weaksBox.Text.Length;
			monthsBox.SelectionStart = monthsBox.Text.Length;
			yearsBox.SelectionStart = yearsBox.Text.Length;

			dayTextInfo.Text = daysText;
			weekTextInfo.Text = weekText;
			monthTextInfo.Text = monthText;
			yearsTextInfo.Text = yearsText;
		}

		private void DaysBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (to is null)
			{
				to = new Calendar();
				from = new Calendar();
			}
			if (to.SelectedDate is null)
			{
				to.SelectedDate = DateTime.Today;
			}
			if (from.SelectedDate is null)
			{
				from.SelectedDate = DateTime.Today;
			}

			if (weaksBox is null || monthsBox is null)
			{
				weaksBox = new TextBox();
				monthsBox = new TextBox();
				yearsBox = new TextBox();
				weaksBox.Text = "0";
				monthsBox.Text = "0";
				yearsBox.Text = "0";
			}

			if (daysBox.Text.Length == 0 || weaksBox.Text.Length == 0 || monthsBox.Text.Length == 0)
			{
				return;
			}
			if (daysBox.Text == "-")
			{
				return;
			}

			int newDays;
			try
			{
				newDays = Convert.ToInt32(daysBox.Text);
			}
			catch
			{
				return;
			}


			DateTime currentDate = from.SelectedDate.Value;
			DateTime newDate = currentDate.AddDays(newDays);
			
			to.SelectedDate = newDate;
			to.DisplayDate = newDate;
		}

		private void WeaksBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (weaksBox is null || monthsBox is null || yearsBox is null)
			{
				weaksBox = new TextBox();
				monthsBox = new TextBox();
				yearsBox = new TextBox();
				weaksBox.Text = "0";
				monthsBox.Text = "0";
				yearsBox.Text = "0";
			}

			if (daysBox.Text.Length == 0 || weaksBox.Text.Length == 0 || monthsBox.Text.Length == 0)
			{
				return;
			}
			if (daysBox.Text == "-")
			{
				return;
			}

			int newWeeks;
			try
			{
				newWeeks = Convert.ToInt32(weaksBox.Text);
			}
			catch
			{
				return;
			}
			try
			{
				DateTime newDate = from.SelectedDate.Value.AddDays(newWeeks * 7);
			}
			catch (System.ArgumentOutOfRangeException)
			{
				MessageBox.Show("Недопустимая дата");
				return;
			}
			
			daysBox.Text = (newWeeks*7).ToString();
		}

		private void MonthsBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (weaksBox is null || monthsBox is null || yearsBox is null)
			{
				weaksBox = new TextBox();
				monthsBox = new TextBox();
				yearsBox = new TextBox();
				weaksBox.Text = "0";
				monthsBox.Text = "0";
				yearsBox.Text = "0";
			}

			if (daysBox.Text.Length == 0 || weaksBox.Text.Length == 0 || monthsBox.Text.Length == 0)
			{
				return;
			}

			int newMonths;
			try
			{
				newMonths = Convert.ToInt32(monthsBox.Text);
			}
			catch
			{
				return;
			}
			try
			{
				DateTime currentDate = from.SelectedDate.Value;

				DateTime newDate = currentDate.AddMonths(newMonths);
				daysBox.Text = (newDate - currentDate).Days.ToString();
			}
			catch (System.ArgumentOutOfRangeException)
			{
				MessageBox.Show("Недопустимая дата");
			}
			
		}


		private void YearsBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (weaksBox is null || monthsBox is null || yearsBox is null)
			{
				weaksBox = new TextBox();
				monthsBox = new TextBox();
				yearsBox = new TextBox();
				weaksBox.Text = "0";
				monthsBox.Text = "0";
				yearsBox.Text = "0";
			}

			int newYears;
			try
			{
				newYears = Convert.ToInt32(yearsBox.Text);
			}
			catch
			{
				return;
			}

			DateTime currentDate = from.SelectedDate.Value;
			try
			{
				daysBox.Text = (currentDate.AddYears(newYears)-currentDate).Days.ToString();
			}
			catch(System.ArgumentOutOfRangeException)
			{
				MessageBox.Show("Недопустимая дата");
				return;
			}
			
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			daysBox.Text = "0";
            weaksBox.Text = "0";
            monthsBox.Text = "0";
			yearsBox.Text = "0";
        }
    }
}
