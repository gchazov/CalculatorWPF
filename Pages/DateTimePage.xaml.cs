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

		private void FirstDate(object sender,
	SelectionChangedEventArgs e)
		{
			DateTime? selectedDate = from.SelectedDate;
			MessageBox.Show((selectedDate - to.SelectedDate).ToString());
		}

		private void SecondDate(object sender,
	SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = to.SelectedDate;
			MessageBox.Show(selectedDate.ToString());
        }
	}
}
