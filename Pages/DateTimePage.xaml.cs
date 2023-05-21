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
    public class GetToday
    {
		public DateTime Today
		{
			get
			{
				return DateTime.Today;
			}
            set
            {
                DateTime d = value;
            }
		}
	}
    
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

		private Calendar selectedFrom;
		private	Calendar selectedTo;

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
				result.Text = "По нулям";
				return;
			}
            string deltaRaw = delta.ToString();
			string[] deltaSplitted = deltaRaw.Split(':');
			// Чтобы корректно считались годы и месяцы, добавляем разницу к минимальному значению календаря
			DateTime deltaCombined = (DateTime) (DateTime.MinValue + delta);

			// Так как минимальное значение - это 1.1.1, то надо везде вычесть 1
			int Years = deltaCombined.Year - 1;
			int Months = deltaCombined.Month - 1;
			int Days = deltaCombined.Day - 1;
			result.Text = Years.ToString() + " Лет\n" + Months.ToString() + " Месяцев\n" + Days.ToString() + " Дней";


		}
	}
}
