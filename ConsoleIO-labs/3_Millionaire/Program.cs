using System;

namespace Millionaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Питання, варіанти відповідей і номер правильної відповіді (з 1)
            string[] questions =
            {
                "Які кольори у прапора України?",
                "В якому місті знаходиться ДТЕУ?",
                "Скільки буде 7 * 8?",
                "Яка мова програмування використовується в цьому завданні?",
                "Яка планета Сонячної системи найбільша?"
            };

            string[][] options =
            {
                new[] { "жовтий і блакитний", "червоний і зелений", "чорний і жовтий", "зелений і фіолетовий" },
                new[] { "Вінниця", "Київ", "Львів", "Одеса" },
                new[] { "54", "56", "58", "64" },
                new[] { "Python", "Java", "C#", "Pascal" },
                new[] { "Земля", "Марс", "Сатурн", "Юпітер" }
            };

            int[] correct = { 1, 2, 2, 3, 4 };

            int score = 0;

            for (int q = 0; q < questions.Length; q++)
            {
                Console.WriteLine($"Current User Score: {score}");
                Console.WriteLine($"Питання {q + 1}, {questions[q]}");
                Console.WriteLine();

                for (int i = 0; i < options[q].Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[q][i]}");
                }
                Console.WriteLine();

                // Повторюємо запит, поки користувач не введе число від 1 до 4
                int answer;
                Console.Write("Ваша відповідь: ");
                while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4)
                {
                    Console.Write("Введіть число від 1 до 4: ");
                }

                if (answer == correct[q])
                {
                    score += 100; // бали нараховуються за кожну правильну відповідь поспіль
                    Console.WriteLine("Correct answer");
                    Console.WriteLine();
                }
                else
                {
                    // Перша ж помилка завершує гру
                    Console.WriteLine("Wrong Answer");
                    Console.WriteLine($"Final User Score: {score}");
                    Console.WriteLine("Кінець програми.");
                    return;
                }
            }

            Console.WriteLine($"Current User Score: {score}");
            Console.WriteLine("Вітаємо! Ви відповіли на всі питання правильно!");
        }
    }
}
