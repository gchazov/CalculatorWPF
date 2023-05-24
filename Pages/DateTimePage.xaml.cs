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
    /// Логика взаимодействия для DateTimePage.xaml
    /// </summary>
    public partial class DateTimePage : Page
    {
		
		public DateTimePage()
        {
            InitializeComponent();
        }

		private void result_TextChanged(object sender, TextChangedEventArgs e)
		{

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

			
			TimeSpan? delta = from.SelectedDate - to.SelectedDate;
			if (from.SelectedDate < to.SelectedDate)
			{
				delta = -delta;
			}
			if (delta is null)
			{
				result.Text = "Ребяты что-то не так пошло";
				return;
			}
			// Чтобы корректно считались годы и месяцы, добавляем разницу к минимальному значению календаря
			DateTime deltaCombined = (DateTime) (DateTime.MinValue + delta);

			// Так как минимальное значение - это 1.1.1, то надо везде вычесть 1
			int Years = deltaCombined.Year - 1;

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
				

			int Months = deltaCombined.Month - 1;

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
			

			int Days = deltaCombined.Day - 1;
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
				
			result.Text = Years.ToString() + $" {yearsText}\n" + Months.ToString() + $" {monthText}\n" + Days.ToString() + $" {daysText}";


		}
	}
}
