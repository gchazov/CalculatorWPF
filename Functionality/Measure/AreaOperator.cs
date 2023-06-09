using CalcYouLate.MeasurePages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CalcYouLate.Functionality
{
    public class AreaOperator: INotifyPropertyChanged
    {
        string _input;
        AreaPage page;
        public string InputValue
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                OnPropertyChanged(OuputValue);
            }
        }
        
        public AreaOperator(Frame frame)
        {
            page = frame.Content as AreaPage;
        }

        public string OuputValue
        {
            get
            {
                //var text = page.FromText;
                //double meters = MeasureList.areaToMeters[text] * Convert.ToDouble(page.InputTextInfo);
                //string result = page.InputTextInfo != "0" ? (meters / MeasureList.areaFromMeters[page.ToText]).ToString() : "Ошибка!";
                return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
