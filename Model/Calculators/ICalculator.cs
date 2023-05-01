using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Calculators
{
    public interface ICalculator
    {
        double? Calculate(string expression);
    }
}
