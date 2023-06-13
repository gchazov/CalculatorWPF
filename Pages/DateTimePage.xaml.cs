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
			to.SelectedDate = DateTime.Today;
		}

        public DateTime GetToday()
        {
            return DateTime.Today;
        }
		private void FirstDate(object sender,
	SelectionChangedEventArgs e)
		{
			DateTime_Result();
		}

		private void SecondDate(object sender,
	SelectionChangedEventArgs e)
        {
            DateTime_Result();
        }


        private void DateTime_Result()
        {
            if (to.SelectedDate is null)
            {
                to.SelectedDate = DateTime.Today;
            }
			if (from.SelectedDate is null)
			{
				from.SelectedDate = DateTime.Today;
			}

			string isNegative = "";
			TimeSpan? delta = to.SelectedDate - from.SelectedDate;
			if (from.SelectedDate > to.SelectedDate)
			{
				isNegative = "";
				delta = -delta;
			}
			if (delta is null)
			{
				resultAppendix.Text = "Ребяты что-то не так пошло";
				return;
			}

			// Так как минимальное значение - это 1.1.1, то надо везде вычесть 1
			int Years = to.SelectedDate.Value.Year - from.SelectedDate.Value.Year;
			int Months = (to.SelectedDate.Value.Year - from.SelectedDate.Value.Year) * 12 + (to.SelectedDate.Value.Month - from.SelectedDate.Value.Month);
			if (to.SelectedDate.Value.Day < from.SelectedDate.Value.Day) // Если день первой даты меньше дня второй даты, то вычитаем один месяц
			{
				--Months;
			}
			int Days = (to.SelectedDate.Value - from.SelectedDate.Value).Days;

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
			daysBox.Text = isNegative + Days.ToString();
			weaksBox.Text = isNegative + (Days /7).ToString();
			monthsBox.Text = isNegative + Months.ToString();
			
			resultAppendix.Text = $"{daysText}\nНедель\n{monthText}";


		}

		private void sidebarDateTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			navDateTimeFrame.Navigate((sidebarDateTime.SelectedItem as NavButton).NavLink);
			
		}

		private void NavButton_Selected(object sender, RoutedEventArgs e)
		{

		}

		private void navDateTimeFrame_Navigated(object sender, NavigationEventArgs e)
		{

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
				weaksBox.Text = "0";
				monthsBox.Text = "0";
			}

			if(daysBox.Text.Length == 0 || weaksBox.Text.Length == 0 || monthsBox.Text.Length == 0)
			{
				return;
			}
			if (daysBox.Text == "-")
			{
				return;
			}

			// Считывание добавляемых дней, недель, месяцев

			int newInputDays = Convert.ToInt32(daysBox.Text);
			int newWeaks = newInputDays / 7;
			DateTime currentDate = from.SelectedDate.Value;
			TimeSpan timeSpan = new TimeSpan(newInputDays, 0, 0, 0);
			DateTime newDate = currentDate + timeSpan;



			//int newInputWeaks = Convert.ToInt32(weaksBox.Text);
			//int newInputMonths = Convert.ToInt32(monthsBox.Text);

			//if (newInputDays == 0 && newInputWeaks == 0 && newInputMonths == 0)
			//{
			//	return;
			//}
			//DateTime currentDate = from.SelectedDate.Value;

			//int newDays = newInputDays + newInputWeaks * 7;
			//TimeSpan timeSpan = new TimeSpan(newDays, 0, 0, 0);
			//// Если месяцев больше 12, то сразу добавляем новые года
			//int newYear = currentDate.Year + newInputMonths / 12;
			//newInputMonths = newInputMonths % 12;

			//int newMonth = currentDate.Month;

			//// Если после добавления месяцев добавляется больше года, то добавляем еще один год и остаток месяцев
			//if (currentDate.Month + newInputMonths > 12)
			//{
			//	newYear += 1;
			//	newMonth = newInputMonths - (12 - currentDate.Month);
			//}
			//else
			//{
			//	newMonth += newInputMonths;
			//}

			//DateTime newDate = new DateTime(newYear, newMonth, currentDate.Day);
			//newDate += timeSpan;
			MessageBox.Show(newDate.ToString());
			to.SelectedDate = newDate;
		}
	}
}
