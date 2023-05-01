using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Calculators
{
    public class ExpressionCalc : ICalculator
    {
        public double? Calculate(string expression)
        {
            DataTable dataTable = new DataTable();
            if (char.IsDigit(expression.Last()))
            {
                var value = dataTable.Compute(expression, string.Empty);
                return Convert.ToDouble(value);
            }
            //else if (!char.IsDigit(expression.Last()))
            //{
            //    string buffer = expression.Reverse().ToString();
            //    int index;
            //    for (index = 0; index < expression.Length; index++)
            //        if (char.IsDigit(buffer[index])) break;

            //    string normalized = buffer.Substring(index).Reverse().ToString();
            //    var value = dataTable.Compute(normalized, string.Empty);
            //    return Convert.ToDouble(value);
            //}
            return null;
        }
    }
}
