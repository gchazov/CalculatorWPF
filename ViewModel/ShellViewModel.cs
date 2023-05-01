using Calculator.Model.Calculators;
using Calculator.ViewModel.Base;
using Microsoft.Practices.Prism.Commands;
using Prism.Mvvm;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Calculator.ViewModel
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public ShellViewModel()
        { }


        private readonly ICalculator _calculator = new ExpressionCalc();
        private string _calculatorText;
        private string _resultText;

        public string Expression
        {
            get => _calculatorText;
            set => SetProperty(ref _calculatorText, value);
        }

        public string Result
        {
            get => _resultText;
            set => SetProperty(ref _resultText, value);
        }

        public DelegateCommand<string> AddNumberCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }

        public DelegateCommand CalculateCommand { get; set; }

        protected override void RegisterCommands()
        {
            AddNumberCommand = new DelegateCommand<string>(AddNumber);
            ClearCommand = new DelegateCommand(Clear);
            CalculateCommand = new DelegateCommand(Calculate);
        }

        private void AddNumber(string value)
        {
            Expression += value;
            Calculate();
        }

        private void Clear()
        {
            Expression = string.Empty;
            Result = string.Empty;
        }

        private void Calculate()
        {
            if (Expression != null)
                Result = _calculator.Calculate(Expression) == null ? "Error" : _calculator.Calculate(Expression).ToString();
        }
    }
}
