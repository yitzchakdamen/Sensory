namespace Sensory
{

    class UserSystem
    {
        public Dal DbManagement;
        User user;
        Game game;
        public UserSystem(Game game)
        {
            this.game = game;
            DbManagement = new();
        }

        public UserSystem Start()
        {
            while (user == null)
            {
                MenuUser();
            }
            PrintMenu.WelcomeBack(user);
            game.Level = user.GameStage;
            game.score = user.Score;
            return this;
        }

        public void MenuUser()
        {
            PrintMenu.MenuUser();

            switch (Console.ReadLine()!)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    CreateUser();
                    break;
                default:
                    PrintMenu.InvalidInput();
                    MenuUser();
                    break;
            }
        }

        public void Login()
        {
            "Enter the user name".Print(6);
            string userName = Console.ReadLine()!;

            if (DbManagement.UsernameCheck(userName))
                user = DbManagement.GetUserByUserName(userName)!;
            else
                $"User does not exist.".Print(1);
        }
        public void CreateUser()
        {
            "Enter the name".Print(6);
            string name = Console.ReadLine()!;
            "Enter the Last name".Print(6);
            string LastName = Console.ReadLine()!;

            if (name == "" || LastName == "")
            {
                PrintMenu.InvalidInput();
                CreateUser();
            }
            string userName = CreateUsername();

            User user = new User.Builder().SetName(name).SetLastName(LastName).SetUserName(userName).Build();

            Console.WriteLine(user);
            DbManagement.Insert(user);
            "User created successfully Continue to login".Print(2);
        }

        public string CreateUsername()
        {
            "Enter the user name".Print(6);
            string userName = Console.ReadLine()!;

            if (userName == "")
            {
                PrintMenu.InvalidInput();
                CreateUsername();
            }
            if (DbManagement.UsernameCheck(userName))
            {
                "Username already exists.".Print(1);
                CreateUsername();
            }
            return userName;
        }

        public void PlayerStatusUpdate(int level, int score)
        {
            if (user != null)
            {
                DbManagement.Update(user.UserName,score, level);
            }   
        }
    }
}
