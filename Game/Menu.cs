namespace Sensory
{
    class Menu
    {
        int gameMoveCont = 0;
        public void Start(Game game)
        {
            bool Victory = false;
            LoginMessage(game);

            while (!Victory)
            {
                if (GameMove(game))
                    Victory = game.Checker();
            }

            Console.WriteLine("\n ------- You won the game ------- \n");
        
        }

        void LoginMessage(Game game)
        {
            Console.Clear();
            Console.WriteLine("\n ---- welcome to Sensory Game ----\n");
            Console.WriteLine($"Number of Agents: {game.AgentsGame.Count}");
        }

        bool GameMove(Game game)
        {
            gameMoveCont++;
            Console.WriteLine($"\n ---> Move: {gameMoveCont}----");
            Console.WriteLine($"\n ----  Select the agent you want to attach a sensor to. (Select a number from 1 to {game.AgentsGame.Count})\n");

            if (int.TryParse(Console.ReadLine(), out int agent) && agent > 0 && agent <= game.AgentsGame.Count)
            {
                while(!SensorSelection(game, agent));
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                return false;
            }

        }

        bool SensorSelection(Game game, int agentIndex)
        {
            Agent agent = game.AgentsGame[agentIndex - 1];
            SensorType[] sensorTypes = (SensorType[])Enum.GetValues(typeof(SensorType));
            

            Console.WriteLine($"\n ----  Select the sensor you want to attach to the agent. ----  \n");

            foreach (SensorType sensorType in sensorTypes)
            {
                Console.WriteLine($"{(int)sensorType}: {sensorType}");
            }
            Console.WriteLine($"\n ----  Select a number from 1 to {sensorTypes.Length}\n");

            if (int.TryParse(Console.ReadLine(), out int sensor) && sensor > 0 && sensor <= sensorTypes.Length)
            {
                Sensor NewSensor = Sensor.AddSensor((SensorType)sensor);
                agent.ActiveSensors.Add(NewSensor);
                game.ActiveSensors(agent);
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                return false;
            }
            
        }
       
    }
    
}