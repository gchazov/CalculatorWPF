using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcYouLate.Functionality.Expressions
{
	public static class Evaluator
	{
		private const string numberChars = "01234567890,";
		private static string[] operatorChars = new string[] { "sin", "cos", "log", "ln", "tg", "!", "sqrt", "abs", "^", "*", "/", "+", "-" };
		// "sin", "cos", "log", "ln", 

		public static double Calculate(string expression)
		{
			if (string.IsNullOrEmpty(expression))
				throw new ArgumentException("Пустое выражение недопустимо", nameof(expression));
			expression = expression.Replace("sin", "1sin")
								   .Replace("cos", "1cos")
								   .Replace("log", "1log")
								   .Replace("ln", "1ln")
								   .Replace("tg", "1tg")
								   .Replace("!", "!1")
								   .Replace("sqrt", "1sqrt")
								   .Replace("abs", "1abs");
			CheckParenthesis(expression);

			return EvaluateParenthesis(expression);
		}

		private static double EvaluateParenthesis(string expression)
		{
			string planarExpression = expression;
			while (planarExpression.Contains('('))
			{
				int clauseStart = planarExpression.IndexOf('(') + 1;
				int clauseEnd = IndexOfRightParenthesis(planarExpression, clauseStart);
				string clause = planarExpression.Substring(clauseStart, clauseEnd - clauseStart);
				planarExpression = planarExpression.Replace("(" + clause + ")", EvaluateParenthesis(clause).ToString());
			}
			return Evaluate(planarExpression);
		}

		private static int IndexOfRightParenthesis(string expression, int start)
		{
			int c = 1;
			for (int i = start; i < expression.Length; i++)
			{
				switch (expression[i])
				{
					case '(': c++; break;
					case ')': c--; break;
				}
				if (c == 0) return i;
			}
			return -1;
		}

		private static void CheckParenthesis(string expression)
		{
			int i = 0;
			foreach (char c in expression)
			{
				switch (c)
				{
					case '(': i++; break;
					case ')': i--; break;
				}
				if (i < 0)
					throw new ArgumentException("Не хватает '('", nameof(expression));
			}
			if (i > 0)
				throw new ArgumentException("Не хватает ')'", nameof(expression));
		}

		private static double Evaluate(string expression)
		{
			string normalExpression = expression.Replace(" ", "");
			List<string> operators = normalExpression.Split(numberChars.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToList();
			List<double> numbers = normalExpression.Split(operatorChars, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList();



			if (operators.Count + 1 != numbers.Count)
				throw new ArgumentException($"Неверный синтаксис в выражении '{expression}'", nameof(expression));

			foreach (string o in operatorChars)
			{
				for (int i = 0; i < operators.Count; i++)
				{
					if (operators[i] == o)
					{
						double result = Calc(numbers[i], numbers[i + 1], o);
						numbers[i] = result;
						numbers.RemoveAt(i + 1);
						operators.RemoveAt(i);
						i--;
					}
				}
			}
			return numbers[0];
		}

		private static double Calc(double left, double right, string oper)
		{
			switch (oper)
			{
				case "sin": return Math.Sin(right);
				case "cos": return Math.Cos(right);
				case "tg": return Math.Tan(right);
				case "ln": return Math.Log(right);
				case "!": return Factorial(left);
				case "abs": return Math.Abs(right);
				case "sqrt": return Math.Sqrt(right);
				case "+": return left + right;
				case "-": return left - right;
				case "*": return left * right;
				case "/": return left / right;
				case "^": return Math.Pow(left, right);

				default: throw new ArgumentException("Неподдерживаемый оператор", nameof(oper));
			}
		}

		private static double Factorial(double num)
		{
			int numInt = Convert.ToInt32(num);
			int result = 1;
			for (int i = 1; i <= numInt; i++)
			{
				result *= i;
			}
			return result;
		}
	}
}
