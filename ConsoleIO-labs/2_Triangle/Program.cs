using System;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть висоту трикутника: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int height) || height <= 0)
            {
                Console.WriteLine("Помилка: потрібно ввести додатне ціле число.");
                return;
            }

            // Ширина однієї "клітинки": кількість цифр найбільшого числа.
            // Потрібно, щоб трикутник не "ламався" для висоти 10 і більше.
            int cell = height.ToString().Length;

            // Зовнішній цикл - рядки: у рядку номер i виводимо число i рівно i разів
            for (int i = 1; i <= height; i++)
            {
                // Відступ зліва, щоб трикутник був по центру
                Console.Write(new string(' ', (height - i) * (cell + 1) / 2));

                // Внутрішній цикл - повторення числа в рядку
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i.ToString().PadLeft(cell) + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
