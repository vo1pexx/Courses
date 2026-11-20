using System;

namespace ReplaceChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть текст: ");
            string text = Console.ReadLine() ?? "";

            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                // Символи нумеруються з 1, а індекс i починається з 0
                int position = i + 1;

                // Порядок перевірок важливий: спочатку 15-й (ділиться і на 3, і на 5),
                // інакше він би замінився на X або 9.
                if (position % 15 == 0)
                {
                    result += '?';
                }
                else if (position % 3 == 0)
                {
                    result += 'X';
                }
                else if (position % 5 == 0)
                {
                    result += '9';
                }
                else
                {
                    result += text[i]; // символ без змін
                }
            }

            Console.WriteLine($"Результат: {result}");
        }
    }
}
