namespace Sensory
{
    public static class PrintMenu
    {
        public static void Print(this SensorType[] sensorTypes)
        {
            $"\n ----  Select the sensor you want to attach to the agent. ----  \n".Print(3);

            foreach (SensorType sensorType in sensorTypes)
            {
                $"{(int)sensorType}: {sensorType}".Print(3);
            }
            $"\n ----  Select a number from 1 to {sensorTypes.Length}\n".Print(5);
        }
        public static void Print(this AgentRank[] agentRanks)
        {
            $"\n ----  Select the rank of the Agent. ----  \n".Print(1);

            foreach (AgentRank RankType in agentRanks)
            {
                $"{(int)RankType}: {RankType}".Print(3);
            }
            $"\n ----  Select a number from 1 to {agentRanks.Length}\n".Print(5);
        }

        public static void Stop()
        {
            "\n Press any key to continue!".Print(1);
            Console.ReadKey();
        }

        public static void LoginMessage(int numberOfAgents, int Level)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string title = " WELCOME TO THE SENSORY GAME ";
            string border = new string('═', title.Length);
            Stop();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║{title}║");
            Console.WriteLine($"╚{border}╝");
            $" Agents Loaded: {numberOfAgents} Level: {Level}".Print(3);
            Console.WriteLine();

            Console.ResetColor();
        }

        static public void InvalidInput()
        {
            "\nInvalid input. Please try again.".Print(1);
        }

        static public void Bye()
        {
            Console.Clear();
            "\n\n\n\nBye, \nthanks for playing. \nWe'd love to see you again sometime.".Print(6);
            Stop(); 
        }

        public static void LogPulseSensor(Agent agent, int status)
        {
            Console.WriteLine("\n========== 🔴 PULSE SENSOR ACTION TRIGGERED 🔴 ==========");
            Console.WriteLine($"Sensor status: {status} (threshold: 3)");
            Console.WriteLine("Effect: Sensor removed from agent's active sensors.");
            Console.WriteLine("========================================================\n");
        }

        public static void LogMotionSensor(Agent agent, int status)
        {
            Console.WriteLine("\n========== 🟠 MOTION SENSOR ACTION TRIGGERED 🟠 ==========");
            Console.WriteLine($"Sensor status: {status} (threshold: 3)");
            Console.WriteLine("Effect: Sensor removed from agent's active sensors.");
            Console.WriteLine("=========================================================\n");
        }

        public static void LogThermalSensor(Agent agent, SensorType revealedSensor)
        {
            Console.WriteLine("\n========== 🔵 THERMAL SENSOR ACTION TRIGGERED 🔵 ==========");
            Console.WriteLine($"Effect: Revealing one of the agent's sensors.");
            Console.WriteLine($"Agent ID: {agent.Id}");
            Console.WriteLine($"Revealed Sensor: {revealedSensor}");
            Console.WriteLine("==========================================================\n");
        }

        public static void LogCellularSensor(Agent agent)
        {
            Console.WriteLine("\n========== 📡 CELLULAR SENSOR ACTION TRIGGERED 📡 ==========");
            Console.WriteLine($"Effect: Displays agent's ID.");
            Console.WriteLine($"Agent ID: {agent.Id}");
            Console.WriteLine("============================================================\n");
        }

        public static void LogVisualSensor(Agent agent)
        {
            Console.WriteLine("\n========== 👁️ VISUAL SENSOR ACTION TRIGGERED 👁️ ==========");
            Console.WriteLine("Effect: Displays full agent profile.");
            Console.WriteLine($"Agent ID: {agent.Id}");
            Console.WriteLine($"Rank: {agent.Rank}");
            Console.WriteLine($"Affiliation: {agent.Affiliation}");
            Console.WriteLine("===========================================================\n");
        }

        public static void  MainMenu()
        {
            "\n==========  Main Menu ==========".Print(3);
            Console.WriteLine("1) ====>>   Continue at your level");
            Console.WriteLine("2) ====>>   Reset game");
            Console.WriteLine("3) ====>>   Exit");
            "\nChoose your option  (1 - 3)".Print(3);
            "===========================================================\n".Print(3);
        }

        public static void MenuUser()
        {
            Stop();
            Console.Clear();
            "\nHello Player!\n1)   I have a username\n2)   Create a new user".Print(3);
            $"\n ----  Select a number from or 2\n".Print(5);
        }

        public static void WelcomeBack(User user)
        {
            "Welcome back ".Print(6);
            $"{user.Name} {user.LastName}".Print(6);
        }

        public static void AgentsExposed(List<Agent> AgentsExposed)
        {
            "\n ==== all agents exposed ==== \n".Print(8);
            foreach (Agent agent in AgentsExposed)
                $"\n ---- Agent Exposed: {agent.Id} Rank: {agent.Rank} ---- \n".Print(8);
            if (AgentsExposed.Count == 0)
                "---- No agents exposed ---- \n".Print(8);
        }

        public static void Print(this string text, int colorCode)
        {
            Console.ForegroundColor = colorCode switch
            {
                1 => ConsoleColor.Red,
                2 => ConsoleColor.Green,
                3 => ConsoleColor.Yellow,
                4 => ConsoleColor.Blue,
                5 => ConsoleColor.Cyan,
                6 => ConsoleColor.Magenta,
                7 => ConsoleColor.White,
                8 => ConsoleColor.Gray,
                _ => ConsoleColor.DarkGray
            };

            Console.WriteLine(text);
            Console.ResetColor();
        }
        
    }


}