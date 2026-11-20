using System;

namespace RemoveWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть текст: ");
            string text = Console.ReadLine() ?? "";

            Console.Write("Скільки слів видалити з початку (X): ");
            if (!int.TryParse(Console.ReadLine(), out int x) || x < 0)
            {
                Console.WriteLine("Помилка: X має бути цілим невід'ємним числом.");
                return;
            }

            // Розбиваємо текст на слова по пробілах.
            // RemoveEmptyEntries ігнорує зайві пробіли між словами.
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Збираємо результат зі слів, починаючи з номера X
            // (слова нумеруються з 0, тому перші X слів пропускаються)
            string result = "";
            for (int i = x; i < words.Length; i++)
            {
                if (result != "")
                {
                    result += " ";
                }
                result += words[i];
            }

            if (result == "")
            {
                Console.WriteLine("Результат: (порожній рядок, усі слова видалено)");
            }
            else
            {
                Console.WriteLine($"Результат: {result}");
            }
        }
    }
}
