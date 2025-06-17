namespace Sensory
{
    class Menu
    {
        int gameMoveCont = 1;
        public void Start(Game game)
        {
            bool Victory = false;
            PrintMenu.LoginMessage(game.AgentsGame.Count);

            while (!Victory)
            {
                GameMove(game);
                game.ActiveAgent(gameMoveCont);
                Victory = game.Checker();
                PrintAgentsExposed(game);

            }
            "\n ------- You won the game ------- \n".Print(5);
        }

        void GameMove(Game game)
        {
            $"\n ___________________________ ( Move: {gameMoveCont} ) ___________________________\n".Print(5);
            gameMoveCont++;

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
            SensorType[] sensorTypes = (SensorType[])Enum.GetValues(typeof(SensorType));

            sensorTypes.Print();

            if (int.TryParse(Console.ReadLine(), out int sensor) && sensor > 0 && sensor <= sensorTypes.Length)
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