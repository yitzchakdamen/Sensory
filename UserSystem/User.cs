namespace Sensory
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int GameStage { get; set; } = 1;
        public int Score { get; set; } = 0;

        public override string ToString()
        {
            return $"Name: {Name}, LastName: {LastName}, UserName: {UserName}, GameStage: {GameStage}, Score: {Score}";
        }

        public class Builder
        {
            private User user = new User();

            public Builder SetName(string name)
            {
                user.Name = name;
                return this;
            }

            public Builder SetLastName(string lastName)
            {
                user.LastName = lastName;
                return this;
            }

            public Builder SetUserName(string userName)
            {
                user.UserName = userName;
                return this;
            }

            public Builder SetGameStage(int gameStage=1)
            {
                user.GameStage = gameStage;
                return this;
            }

            public Builder SetScore(int score=0)
            {
                user.Score = score;
                return this;
            }

            public User Build()
            {
                return user;
            }
        }
    }
}
