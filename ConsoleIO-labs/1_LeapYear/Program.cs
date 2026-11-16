using System;

namespace LeapYear
{
    internal class Program
    {
        // Перевірка року на високосність за трьома правилами завдання
        static bool IsLeap(int year)
        {
            if (year % 400 == 0) return true;   // кожен 400-й рік - високосний
            if (year % 100 == 0) return false;  // кожен 100-й рік - НЕ високосний
            return year % 4 == 0;               // кожен 4-й рік - високосний
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть рік: ");
            string? input = Console.ReadLine();

            // TryParse не "падає" на некоректному вводі (літери, порожній рядок)
            if (!int.TryParse(input, out int year) || year <= 0)
            {
                Console.WriteLine("Помилка: потрібно ввести додатне ціле число.");
                return;
            }

            if (IsLeap(year))
                Console.WriteLine($"{year} - високосний рік.");
            else
                Console.WriteLine($"{year} - НЕ високосний рік.");
        }
    }
}
