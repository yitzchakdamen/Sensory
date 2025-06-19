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
                    PrintAgentsExposed(game);
                }
                Victory(game);
            }

        }

        void GameMove(Game game)
        {
            $"\n ___________________________ ( Move: {game.gameMoveCont} ) ___________________________\n".Print(5);
            game.gameMoveCont++;

            int agent;
            while (!(AgentSelection(game) is int intAgent && (agent = intAgent) > 0)){}
            while (!SensorSelection(game, agent)){}
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

        bool SensorSelection(Game game, int agentIndex)
        {
            Agent agent = game.AgentsGame[agentIndex - 1];

            game.sensorTypes.Print();

            if (int.TryParse(Console.ReadLine(), out int sensor) && sensor > 0 && sensor <= game.sensorTypes.Length)
            {
                MakingAMove(game, sensor, agent);
                return true;
            }
            else
            {
                PrintMenu.InvalidInput();
                return false;
            }

        }

        void MakingAMove(Game game, int sensor, Agent agent)
        {
            Sensor NewSensor = SensorFactory.Sensor((SensorType)sensor);
            agent.ActiveSensors.Add(NewSensor);
            game.ActiveSensors(agent);
        }

        void Victory(Game game)
        {
            "\n ------- You won the game ------- \n".Print(5);
            game.score += 4 * game.Level - 2 * game.gameMoveCont;
            game.Level += 1; 
            $"\n ------- You score is: {game.score} and the Level is: {game.Level} ------- \n".Print(5);
        }

        void PrintAgentsExposed(Game game)
        {
            "\n ==== all agents exposed ==== \n".Print(8);
            foreach (Agent agent in game.AgentsExposed)
            {
                $"\n ---- Agent Exposed: {agent.Id} Rank: {agent.Rank} ---- \n".Print(8);
            }
            if (game.AgentsExposed.Count == 0)
            {
                "\n ---- No agents exposed ---- \n".Print(8);
            }
        
            // Console.WriteLine($"The most Exposed senior agent is: {sensorTypes[^1]}");

        }
    }
    
}