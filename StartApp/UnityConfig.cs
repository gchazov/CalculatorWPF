using Calculator.Model.Calculators;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.StartApp
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterInstances(this IUnityContainer container) 
        {
            container.RegisterType<ICalculator, ExpressionCalc>();
            return container;
        }
    }
}
