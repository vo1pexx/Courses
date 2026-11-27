namespace SocialNetwork {
    // Соціальна мережа: усі дії користувачів
    class Network {
        public List<User> Users = new List<User>();

        public User RegisterUser(string name, string email, string nickname) {
            User user = new User(name, email, nickname);
            Users.Add(user);
            return user;
        }

        // Останні N постів користувача (від новіших до старіших)
        public List<Post> GetLastPosts(User owner, int count) {
            List<Post> sorted = new List<Post>(owner.Posts);
            sorted.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt));

            List<Post> result = new List<Post>();
            for (int i = 0; i < sorted.Count && i < count; i++) {
                result.Add(sorted[i]);
            }
            return result;
        }

        public void PrintLastPosts(User viewer, User owner, int count) {
            Console.WriteLine($"{viewer.Nickname} дивиться останні {count} постів користувача {owner.Nickname}:\n");
            List<Post> posts = GetLastPosts(owner, count);
            if (posts.Count == 0) {
                Console.WriteLine("  Постів немає.\n");
                return;
            }
            foreach (Post post in posts) {
                post.Print();
            }
        }

        public bool LikePost(User actor, Post post) {
            if (post.Author == actor) {
                Console.WriteLine($"{actor.Nickname}: не можна лайкати власний пост #{post.Id}.");
                return false;
            }
            if (post.LikedBy.Contains(actor)) {
                Console.WriteLine($"{actor.Nickname}: ви вже лайкнули пост #{post.Id}.");
                return false;
            }
            post.LikedBy.Add(actor);
            Console.WriteLine($"{actor.Nickname} поставив лайк посту #{post.Id} ({post.Author.Nickname}).");
            return true;
        }

        public bool CommentPost(User actor, Post post, string text) {
            if (post.Author == actor) {
                Console.WriteLine($"{actor.Nickname}: коментувати можна лише пости інших користувачів.");
                return false;
            }
            post.Comments.Add(new Comment(actor, text));
            Console.WriteLine($"{actor.Nickname} прокоментував пост #{post.Id} ({post.Author.Nickname}).");
            return true;
        }

        public Post CreatePost(User author, string text) {
            Post post = new Post(author, text, DateTime.Now);
            author.Posts.Add(post);
            Console.WriteLine($"{author.Nickname} створив новий пост #{post.Id}.");
            return post;
        }

        public bool DeletePost(User actor, Post post) {
            if (post.Author != actor) {
                Console.WriteLine($"{actor.Nickname}: можна видаляти лише власні пости (пост #{post.Id} належить {post.Author.Nickname}).");
                return false;
            }
            actor.Posts.Remove(post);
            Console.WriteLine($"{actor.Nickname} видалив пост #{post.Id}.");
            return true;
        }
    }
}
