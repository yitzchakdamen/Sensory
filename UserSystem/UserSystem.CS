namespace Sensory
{

    class UserSystem
    {
        public UserSystem(Game game)
        {
            game.Level = 2;
            game.Initialization();
        }
    }

    public class User
    {
        string Name { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        int GameStage { get; set; }
        int Score { get; set; }
        public User(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        


    }
    
}