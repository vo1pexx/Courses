namespace SocialNetwork {
    class Comment {
        public User Author;
        public string Text;
        public DateTime CreatedAt;

        public Comment(User author, string text) {
            Author = author;
            Text = text;
            CreatedAt = DateTime.Now;
        }
    }
}
