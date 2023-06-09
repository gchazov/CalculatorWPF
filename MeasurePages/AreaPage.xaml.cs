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
        public string FromText { get { return from.Text; } }
        public string ToText { get { return to.Text; } }
        public string InputTextInfo { get { return input.Text; } }
        public string OutputTextInfo { get { return output.Text; } }

        public AreaPage CurrentPage
        {
            get
            {
                return this;
            }
        }

        public string ConvertArea
        {
            get
            {
                double meters = CalcYouLate.Functionality.MeasureList.areaToMeters[from.Text] * Convert.ToDouble(input.Text);
                string result = input.Text != "0" ? (meters / CalcYouLate.Functionality.MeasureList.areaFromMeters[to.Text]).ToString() : "Ошибка!";
                return result;
            }
        }

        public AreaPage()
        {
            InitializeComponent();
            DataContext = new Functionality.MeasureList();
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ТУТ ПОКА ПРОСТО РАБОТОСПОСОБНОСТЬ СМОТРЕТЬ!!! ОНА НИЧЕ НЕ СЧИТАЕТ!!!
            
        }
    }
}
