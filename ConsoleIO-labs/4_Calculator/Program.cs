using System;
using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        // Вираз без пробілів і поточна позиція розбору
        static string expr = "";
        static int pos;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Приклад: 5 + 5 * 10 + 4 / 2 - 3");
            Console.Write("Введіть вираз: ");
            expr = (Console.ReadLine() ?? "").Replace(" ", "").Replace(',', '.');
            pos = 0;

            try
            {
                if (expr.Length == 0)
                    throw new FormatException("порожній вираз");

                double result = ParseExpression();

                // Якщо після розбору лишилися символи - у виразі є помилка
                if (pos < expr.Length)
                    throw new FormatException($"неочікуваний символ '{expr[pos]}'");

                Console.WriteLine($"Відповідь: {result.ToString(CultureInfo.InvariantCulture)}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Помилка: ділення на нуль.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Помилка у виразі: {ex.Message}.");
            }
        }

        // Метод рекурсивного спуску. Кожен рівень відповідає за свій пріоритет:
        //   вираз   = доданок { (+|-) доданок }   - найнижчий пріоритет
        //   доданок = множник { (*|/) множник }   - вищий пріоритет
        //   множник = число | -множник | ( вираз )
        // Завдяки цьому * і / виконуються раніше, ніж + і -.

        static double ParseExpression()
        {
            double value = ParseTerm();
            while (pos < expr.Length && (expr[pos] == '+' || expr[pos] == '-'))
            {
                char op = expr[pos++];
                double right = ParseTerm();
                value = op == '+' ? value + right : value - right;
            }
            return value;
        }

        static double ParseTerm()
        {
            double value = ParseFactor();
            while (pos < expr.Length && (expr[pos] == '*' || expr[pos] == '/'))
            {
                char op = expr[pos++];
                double right = ParseFactor();
                if (op == '*')
                {
                    value *= right;
                }
                else
                {
                    if (right == 0) throw new DivideByZeroException();
                    value /= right;
                }
            }
            return value;
        }

        static double ParseFactor()
        {
            if (pos >= expr.Length)
                throw new FormatException("вираз закінчився передчасно");

            // Унарний мінус: -5
            if (expr[pos] == '-')
            {
                pos++;
                return -ParseFactor();
            }

            // Дужки: ( ... )
            if (expr[pos] == '(')
            {
                pos++;
                double inner = ParseExpression();
                if (pos >= expr.Length || expr[pos] != ')')
                    throw new FormatException("відсутня закриваюча дужка");
                pos++;
                return inner;
            }

            // Число (цілі та дробові)
            int start = pos;
            while (pos < expr.Length && (char.IsDigit(expr[pos]) || expr[pos] == '.'))
                pos++;

            if (start == pos)
                throw new FormatException($"неочікуваний символ '{expr[pos]}'");

            if (!double.TryParse(expr.Substring(start, pos - start),
                    NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                throw new FormatException("некоректне число");

            return number;
        }
    }
}
