using CalcYouLate.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CalcYouLate.MeasurePages
{
    /// <summary>
    /// Логика взаимодействия для AreaPage.xaml
    /// </summary>
    public partial class AreaPage : Page
    {
        public string ConvertArea
        {
            get
            {
                double meters = MeasureList.areaToMeters[from.Text] * Convert.ToDouble(input.Text);
                string result = input.Text != "0" ? (meters / MeasureList.areaFromMeters[to.Text]).ToString() : "Ошибка!";
                return result;
            }
        }

        public AreaPage()
        {
            InitializeComponent();
            DataContext = new Functionality.MeasureList();
        }

        private void input_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //ТУТ ПОКА ПРОСТО РАБОТОСПОСОБНОСТЬ СМОТРЕТЬ!!! ОНА НИЧЕ НЕ СЧИТАЕТ!!!
            output.Text = (Convert.ToDouble(input.Text) * Convert.ToDouble(MeasureList.areaToMeters[from.Text])).ToString();
        }
    }
}
