namespace Sensory
{
    class Menu
    {
        public bool MainStart(Game game)
        {
            PrintMenu.MainMenu();

            switch (Console.ReadLine()!)
            {
                case "1":
                    break;
                case "2":
                    game.Level = 1;
                    game.score = 0;
                    break;
                case "3":
                    PrintMenu.Bye();
                    return false;
                default:
                    PrintMenu.InvalidInput();
                    MainStart(game);
                    break;
            }

            game.Initialization();
            return true;
        }

        public void Start(Game game)
        {
            while (MainStart(game))
            {
                bool victory = false;
                PrintMenu.LoginMessage(game.AgentsGame.Count, game.Level);

                while (!victory)
                {
                    GameMove(game);
                    game.ActiveAgent(game.gameMoveCont);
                    victory = game.Checker();
                    PrintMenu.AgentsExposed(game.AgentsExposed);
                }
                Victory(game);
            }

        }

        void GameMove(Game game)
        {
            $"\n ___________________________ ( Move: {game.gameMoveCont} ) ___________________________\n".Print(5);
            game.gameMoveCont++;

            int agent;
            int sensor;

            while (!(AgentSelection(game) is int intAgent && (agent = intAgent) > 0)) { }
            while (!(SensorSelection(game) is int intsensor && (sensor = intsensor) > 0)) { }

            MakingAMove(game, sensor, agent);
        }

        int? AgentSelection(Game game)
        {
            $"\n ----  Select the agent you want to attach a sensor to. (Select a number from 1 to {game.AgentsGame.Count})\n".Print(3);

            if (int.TryParse(Console.ReadLine(), out int agent) && agent > 0 && agent <= game.AgentsGame.Count)
                return agent;
            else
                PrintMenu.InvalidInput();
            return null;
        }

        int? SensorSelection(Game game)
        {
            game.sensorTypes.Print();

            if (int.TryParse(Console.ReadLine(), out int sensor) && sensor > 0 && sensor <= game.sensorTypes.Length)
                return sensor;
            else
                PrintMenu.InvalidInput();
            return null;
        }

        void MakingAMove(Game game, int sensor, int agentIndex)
        {
            Agent agent = game.AgentsGame[agentIndex - 1];
            Sensor NewSensor = SensorFactory.Sensor((SensorType)sensor);

            agent.ActiveSensors.Add(NewSensor);
            game.ActiveSensors(agent);
        }

        void Victory(Game game)
        {
            "\n ------- You won the game ------- ".Print(5);
            game.score += Math.Max((6 * (game.Level + 1)) - (2 * game.gameMoveCont),0);
            game.Level += 1; 
            $" ------- You score is: {game.score} and the Level is: {game.Level} ------- \n".Print(5);
        }
    }
    
}