using System;
using System.Globalization;

namespace Area
{
    internal class Program
    {
        // Зчитує додатне число. Приймає і крапку, і кому (2.5 та 2,5).
        // Запитує знову, поки користувач не введе коректне значення.
        static double ReadPositive(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
                    && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Помилка: введіть додатне число.");
            }
        }

        static void PrintArea(double area)
        {
            // "0.##" - до двох знаків після крапки, зайві нулі не виводяться
            Console.WriteLine($"Площа = {area.ToString("0.##", CultureInfo.InvariantCulture)}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Площу якої фігури обчислити?");
            Console.WriteLine("1. Квадрат");
            Console.WriteLine("2. Круг");
            Console.WriteLine("3. Прямокутник");
            Console.WriteLine("4. Трикутник");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    double side = ReadPositive("Введіть сторону квадрата: ");
                    PrintArea(side * side);
                    break;

                case "2":
                    double radius = ReadPositive("Введіть радіус круга: ");
                    PrintArea(Math.PI * radius * radius);
                    break;

                case "3":
                    double sideA = ReadPositive("Введіть першу сторону: ");
                    double sideB = ReadPositive("Введіть другу сторону: ");
                    PrintArea(sideA * sideB);
                    break;

                case "4":
                    double baseLength = ReadPositive("Введіть основу трикутника: ");
                    double height = ReadPositive("Введіть висоту трикутника: ");
                    PrintArea(baseLength * height / 2);
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Введіть число від 1 до 4.");
                    break;
            }
        }
    }
}
