using System;

namespace ReverseNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть ціле число: ");
            string? input = Console.ReadLine();

            // TryParse не "падає" на некоректному вводі
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Помилка: потрібно ввести ціле число.");
                return;
            }

            // Запам'ятовуємо знак і далі працюємо з модулем числа.
            // long потрібен, бо перевернене число може бути більшим за int.
            bool isNegative = number < 0;
            long rest = Math.Abs((long)number);
            long reversed = 0;

            // Відриваємо останню цифру (% 10) і дописуємо її в кінець результату.
            // Потім відкидаємо цю цифру з початкового числа (/ 10).
            // Приклад: 123 -> reversed 3 -> 32 -> 321
            while (rest > 0)
            {
                int lastDigit = (int)(rest % 10);
                reversed = reversed * 10 + lastDigit;
                rest = rest / 10;
            }

            // Повертаємо знак
            if (isNegative)
            {
                reversed = -reversed;
            }

            Console.WriteLine($"Результат: {reversed}");
        }
    }
}
