using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CalcYouLate.Functionality.Expressions
{
	public class Evaluator : INotifyPropertyChanged
	{
		string _input;
		public string InputValue
		{
			get
			{
				return _input;
			}
			set
			{
				_input = value;
				OnPropertyChanged("OutputValue");
			}
		}
		string _output;
		public string OutputValue
		{
			get
			{
				return MakeCalculation(_input).ToString();
			}
			set
			{
				_output = value;
			}
		
		}

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName));
		}
        public event PropertyChangedEventHandler PropertyChanged;



        private static double Factorial(long num)
		{
			int result = 1;
			for (int i = 1; i <= num; i++)
			{
				result *= i;
			}
			return result;
		}

		// Определение приоритета операций
		static int GetPriority(string op)
		{
			switch (op)
			{
				case "+":
				case "-":
					return 1;
				case "*":
				case "/":
					return 2;
				case "^":
					return 3;
				case "sin":
				case "cos":
				case "tg":
				case "ctg":
				case "log":
				case "ln":
				case "abs":
				case "sqrt":
				case "!":
					return 4;
				default:
					return 0;
			}
		}

		// Вычисление результата бинарной операции
		static double Calculate(double x, double y, string op)
		{
			switch (op)
			{
				case "+":
					return x + y;
				case "-":
					return x - y;
				case "*":
					return x * y;
				case "/":
					return x / y;
				case "^": // Добавляем новый оператор для возведения в степень
					return Math.Pow(x, y);
				case "!":
					return Factorial(Convert.ToInt64(x));



				default:
					throw new ArgumentException("Неверный оператор");
			}
		}

		// Вычисление результата унарной операции
		static double Calculate(double x, string op)
		{
			switch (op)
			{
				case "sin":
					return Math.Sin(x);
				case "cos":
					return Math.Cos(x);
				// Костыль чтобы хотя бы иногда получался табличный ноль
				case "tg":
					return Math.Round(Math.Tan(x), 14);
				case "ctg":
					return 1 / Math.Round(Math.Tan(x), 14);
				case "log":
					return Math.Log10(x);
				case "ln":
					return Math.Log(x);
				case "abs":
					return Math.Abs(x);
				case "sqrt":
					return Math.Sqrt(x);
				default:
					throw new ArgumentException("Неверный оператор");
			}
		}

		// Преобразование выражения в обратную польскую запись	//сам писал??
		static List<string> ToPostfix(string expression)
		{
			expression = expression.Replace("(-", "(0-")
								   .Replace(".", ",")
								   .Replace("!", "!1");
			if (expression[0] == '-')
			{
				expression = "0" + expression;
			}

			// Разбиение выражения на токены по регулярному выражению
			var tokens = Regex.Split(expression, @"(\+|-|\*|/|\(|\)|sin|cos|tan|\^|log|ln|abs|!|sqrt)").Where(t => !string.IsNullOrEmpty(t)).ToList(); // Добавляем новый оператор в регулярное выражение

			// Стек для хранения операторов
			var stack = new Stack<string>();

			// Список для хранения результата
			var result = new List<string>();

			foreach (var token in tokens)
			{
				// Если токен - число, добавляем его в результат
				if (double.TryParse(token, out _))
				{
					result.Add(token);
				}
				// Если токен - открывающая скобка, добавляем ее в стек
				else if (token == "(")
				{
					stack.Push(token);
				}
				// Если токен - закрывающая скобка, выталкиваем из стека все операторы до открывающей скобки и добавляем их в результат
				else if (token == ")")
				{
					while (stack.Count > 0 && stack.Peek() != "(")
					{
						result.Add(stack.Pop());
					}
					if (stack.Count == 0)
					{
						throw new ArgumentException("Незакрытые скобки");
					}
					stack.Pop(); // Удаляем открывающую скобку из стека
				}
				// Если токен - оператор, выталкиваем из стека все операторы с большим или равным приоритетом и добавляем их в результат, затем добавляем токен в стек
				else
				{
					while (stack.Count > 0 && GetPriority(stack.Peek()) >= GetPriority(token))
					{
						result.Add(stack.Pop());
					}
					stack.Push(token);
				}
			}

			// Выталкиваем из стека все оставшиеся операторы и добавляем их в результат
			while (stack.Count > 0)
			{
				var op = stack.Pop();
				if (op == "(" || op == ")")
				{
					throw new ArgumentException("Незакрытые скобки");
				}
				result.Add(op);
			}

			return result;
		}

		// Вычисление результата выражения в обратной польской записи
		static double Evaluate(List<string> postfix)
		{
			// Стек для хранения промежуточных результатов
			var stack = new Stack<double>();

			foreach (var token in postfix)
			{
				// Если токен - число, добавляем его в стек
				if (double.TryParse(token, out double value))
				{
					stack.Push(value);
				}
				// Если токен - бинарный оператор, выталкиваем из стека два числа, вычисляем результат операции и добавляем его в стек
				else if (token == "+" || token == "-" || token == "*" || token == "/" || token == "^" || token == "!") // Добавляем новый оператор в условие
				{
					if (stack.Count < 1)
					{
						throw new ArgumentException("Ошибка в выражении");
					}
					try 
					{
                        var y = stack.Pop();
                        var x = stack.Pop();
						
                        var result = Calculate(x, y, token);
						if (Math.Round(result, 14) == 0.0)
						{
							result = 0;
						}
						stack.Push(result);
                    }
					catch(Exception e)
					{
						throw new ArgumentException("Ошибка в выражении");
                    }
				}
				// Если токен - унарный оператор, выталкиваем из стека одно число, вычисляем результат операции и добавляем его в стек
				else if ((new string[] { "sin", "cos", "tg", "ctg", "abs", "sqrt", "log", "ln" }).Contains(token))
				{
					if (stack.Count < 1)
					{
						throw new ArgumentException("Ошибка в выражении");
					}
					
					var x = stack.Pop();
					
					var result = Calculate(x, token);
					if (Math.Round(result, 14) == 0.0)
					{
						result = 0;
					}
					stack.Push(result);
				}
				else
				{
					throw new ArgumentException("Ошибка в выражении");
				}
			}

			// В стеке должно остаться одно число - результат выражения
			if (stack.Count != 1)
			{
				throw new ArgumentException("Ошибка в выражении");
			}
			return stack.Pop();
		}

		public static double MakeCalculation(string expression)
		{
			if (expression != null && expression != string.Empty)
			{
				expression = expression.Replace("π", $"{Math.PI}")
					.Replace("e", $"{Math.E}");
				return Math.Round(Evaluate(ToPostfix(expression)), 8);
			}
			else { return 0;}
		}
	}
}
