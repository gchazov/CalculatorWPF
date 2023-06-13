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
    /// Логика взаимодействия для MeasurePage.xaml
    /// </summary>
    public partial class MeasurePage : Page
    {
        public MeasurePage()
        {
            InitializeComponent();
        }

        private void sidebarMeasures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            navMeasureFrame.Navigate((sidebarMeasures.SelectedItem as NavButton).NavLink);
        }

		private void NavButton_Selected(object sender, RoutedEventArgs e)
		{

		}
	}
}
