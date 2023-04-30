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
        public ShellViewModel()
        {
            
        }

        private string _calculatorText;

        public string CalcText
        {
            get => _calculatorText;
            set => SetProperty(ref _calculatorText, value);
        }

        public DelegateCommand<string> AddNumberCommand { get; set; }

        protected override void RegisterCommands()
        {
            AddNumberCommand = new DelegateCommand<string>(AddNumber);
        }

        private void AddNumber(string obj)
        {
            CalcText += "5";
        }
    }
}
