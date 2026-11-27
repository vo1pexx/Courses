namespace SocialNetwork {
    class Post {
        private static int nextId = 1;

        public int Id;
        public User Author;
        public string Text;
        public DateTime CreatedAt;
        public List<User> LikedBy = new List<User>();
        public List<Comment> Comments = new List<Comment>();

        public int Likes {
            get { return LikedBy.Count; }
        }

        public Post(User author, string text, DateTime createdAt) {
            Id = nextId;
            nextId++;
            Author = author;
            Text = text;
            CreatedAt = createdAt;
        }

        // Повна інформація про пост
        public void Print() {
            Console.WriteLine($"Пост #{Id} | {CreatedAt:dd.MM.yyyy HH:mm} | Автор: {Author.Nickname}");
            Console.WriteLine($"  Текст: {Text}");
            Console.WriteLine($"  Лайків: {Likes}");
            Console.WriteLine($"  Коментарі ({Comments.Count}):");
            foreach (Comment comment in Comments) {
                Console.WriteLine($"    - {comment.Author.Nickname} ({comment.CreatedAt:dd.MM.yyyy HH:mm}): {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
