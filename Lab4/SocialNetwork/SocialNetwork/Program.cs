namespace SocialNetwork {
    internal class Program {

        static void Header(string title) {
            Console.WriteLine("==================================================");
            Console.WriteLine(title);
            Console.WriteLine("==================================================");
        }

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Network network = new Network();

            // Користувачі (дані описані в коді)
            User olena = network.RegisterUser("Олена Коваль", "olena@example.com", "@olena");
            User taras = network.RegisterUser("Тарас Шевчук", "taras@example.com", "@taras");
            User maria = network.RegisterUser("Марія Іваненко", "maria@example.com", "@maria");

            // Початкові пости з різними датами (у Олени їх 7, щоб було видно вибірку "останні 5")
            olena.Posts.Add(new Post(olena, "Перший пост у мережі!", DateTime.Now.AddDays(-7)));
            olena.Posts.Add(new Post(olena, "Вчу C#, поки що цікаво.", DateTime.Now.AddDays(-6)));
            olena.Posts.Add(new Post(olena, "Каву вранці ніхто не скасовував.", DateTime.Now.AddDays(-5)));
            olena.Posts.Add(new Post(olena, "Сьогодні була пара з програмування.", DateTime.Now.AddDays(-4)));
            olena.Posts.Add(new Post(olena, "Здала лабораторну вчасно!", DateTime.Now.AddDays(-3)));
            olena.Posts.Add(new Post(olena, "Вихідні планую провести на природі.", DateTime.Now.AddDays(-2)));
            olena.Posts.Add(new Post(olena, "Хто йде завтра на пару?", DateTime.Now.AddDays(-1)));

            taras.Posts.Add(new Post(taras, "Всім привіт!", DateTime.Now.AddDays(-3)));
            taras.Posts.Add(new Post(taras, "Дивлюсь відео про кібербезпеку.", DateTime.Now.AddDays(-1)));

            maria.Posts.Add(new Post(maria, "Новий день - нові задачі.", DateTime.Now.AddDays(-2)));

            Header("1. @taras дивиться останні 5 постів @olena");
            network.PrintLastPosts(taras, olena, 5);

            Header("2. Лайки");
            List<Post> olenaLast = network.GetLastPosts(olena, 5);
            Post targetPost = olenaLast[0];                 // найновіший пост Олени
            network.LikePost(taras, targetPost);
            network.LikePost(maria, targetPost);
            network.LikePost(taras, targetPost);            // повторний лайк - відмова
            network.LikePost(olena, targetPost);            // лайк власного поста - відмова
            Console.WriteLine();

            Header("3. Коментарі");
            network.CommentPost(taras, targetPost, "Я буду!");
            network.CommentPost(maria, targetPost, "Я теж, зустрінемось біля входу.");
            network.CommentPost(olena, targetPost, "Коментар від автора");   // відмова
            Console.WriteLine();
            targetPost.Print();

            Header("4. @maria створює новий пост");
            Post newPost = network.CreatePost(maria, "Мій перший пост про C#!");
            Console.WriteLine();
            network.PrintLastPosts(maria, maria, 5);

            Header("5. Видалення постів");
            network.DeletePost(taras, newPost);             // чужий пост - відмова
            network.DeletePost(maria, newPost);             // свій пост - успішно
            Console.WriteLine($"\nУ @maria залишилось постів: {maria.Posts.Count}");
        }
    }
}
