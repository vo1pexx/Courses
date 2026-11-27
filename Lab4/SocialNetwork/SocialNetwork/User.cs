namespace SocialNetwork {
    class User {
        public string Name;
        public string Email;
        public string Nickname;   // у форматі @nickname
        public List<Post> Posts = new List<Post>();

        public User(string name, string email, string nickname) {
            Name = name;
            Email = email;
            Nickname = nickname;
        }
    }
}
