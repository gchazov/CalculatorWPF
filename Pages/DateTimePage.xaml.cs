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


			int Years = to.SelectedDate.Value.Year - from.SelectedDate.Value.Year;
			if (to.SelectedDate.Value.Month < from.SelectedDate.Value.Month && to.SelectedDate.Value > from.SelectedDate.Value)
			{
				--Years;
			}

			int Months = (to.SelectedDate.Value.Year - from.SelectedDate.Value.Year) * 12 + (to.SelectedDate.Value.Month - from.SelectedDate.Value.Month);
			if (to.SelectedDate.Value.Day < from.SelectedDate.Value.Day && to.SelectedDate.Value > from.SelectedDate.Value) // Если день первой даты меньше дня второй даты, то вычитаем один месяц
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

			yearsBox.Text = Years.ToString();
			monthsBox.Text = Months.ToString();
			weaksBox.Text = (Days / 7).ToString();
			daysBox.Text = Days.ToString();

			daysBox.SelectionStart = daysBox.Text.Length;
			weaksBox.SelectionStart = weaksBox.Text.Length;
			monthsBox.SelectionStart = monthsBox.Text.Length;
			yearsBox.SelectionStart = yearsBox.Text.Length;

			resultAppendix.Text = $"{daysText}\nНедель\n{monthText}\n{yearsText}";
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

			MessageBox.Show(newDate.ToString());

			to.SelectedDate = newDate;
		}

		private void WeaksBox_TextChanged(object sender, TextChangedEventArgs e)
		{
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

			int newWeeks;
			try
			{
				newWeeks = Convert.ToInt32(weaksBox.Text);
			}
			catch
			{
				return;
			}

			DateTime newDate = from.SelectedDate.Value.AddDays(newWeeks*7);
			to.SelectedDate= newDate;
		}

		private void MonthsBox_TextChanged(object sender, TextChangedEventArgs e)
		{
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
			int newMonths;
			try
			{
				newMonths = Convert.ToInt32(monthsBox.Text);
			}
			catch
			{
				return;
			}
			
			DateTime currentDate = from.SelectedDate.Value;

			DateTime newDate = currentDate.AddMonths(newMonths);
			to.SelectedDate = newDate;
		}
		private void YearsBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (weaksBox is null || monthsBox is null)
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

			DateTime newDate = currentDate.AddYears(newYears);
			to.SelectedDate = newDate;
		}
	}
}
