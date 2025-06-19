using System.Dynamic;
using System.Text.RegularExpressions;

namespace Sensory
{


    class Game
    {
        private static Game _instance;
        public List<Agent> AgentsGame = new();
        public List<Agent> AgentsExposed = new();
        public AgentRank[] agentRanks = (AgentRank[])Enum.GetValues(typeof(AgentRank));
        public SensorType[] sensorTypes = (SensorType[])Enum.GetValues(typeof(SensorType));
        public int Level = 1;
        public int score = 0;
        public int gameMoveCont = 1;
        public Random rnd = new();

        private Game() { }

        public static Game instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }

        public void Initialization()
        {
            for (int i = 1; i <= Level; i++)
            {
                int Index = rnd.Next(1, Level + 1);
                AgentsGame.Add(AgentFactory.Agent((AgentRank)Index)); 
            }
        }

        public bool Checker()
        {
            bool Victory = true;
            AgentsExposed.Clear();
            " === checker agents === ".Print(6);
            foreach (Agent agent in AgentsGame)
            {
                if (CheckerAgent(agent.ActiveSensors, agent.Sensors))
                    AgentsExposed.Add(agent);
                else
                    Victory = false;
            }
            return Victory;

        }

        bool CheckerAgent(List<Sensor> ActiveSensors, Dictionary<SensorType, int> Sensors)
        {
            var Status = ActiveSensors.GroupBy(Sensor => Sensor.Type).ToDictionary(Group => Group.Key, Group => Group.Count());

            int QuantityActual = 0;
            int QuantityRequired = 0;

            foreach (var item in Sensors)
            {
                var SensorType = item.Key;
                int QuantitySensor = item.Value;

                if (Status.TryGetValue(SensorType, out int QuantityActiveSensors))
                {
                    if (QuantitySensor > QuantityActiveSensors)
                        QuantityActual += QuantityActiveSensors;
                    else
                        QuantityActual += QuantitySensor;
                }
                QuantityRequired += QuantitySensor;
            }

            $"\n Agent XXX --- Actual Quantity : {QuantityActual}, Required Quantity: {QuantityRequired} ---\n number of active sensors: {ActiveSensors.Count}".Print(6);

            if (QuantityActual < QuantityRequired)
            {
                return false;
            }
            return true;

        }

        public void ActiveSensors(Agent agent)
        {
            "\n === active sensors === ".Print(2);
            foreach (Sensor Sensors in agent.ActiveSensors.ToList())
            {
                $"\n === sensor: {Sensors.Type} === ".Print(2);
                Sensors.Active();
                Sensors.UniqueAction(agent);
            }
        }
        public void ActiveAgent(int gameMove)
        {
            "\n === active agent === \n".Print(1);
            foreach (Agent agent in AgentsGame)
            {
                if (gameMove % 5 == 0)
                {
                    agent.AgentActivate();
                }
                else if (agent.Rank == AgentRank.OrganizationLeader && gameMove % 10 == 0)
                {
                    GamePropertyAgents.OrganizationLeader organizationLeader = (GamePropertyAgents.OrganizationLeader)agent;
                    organizationLeader.OrganizationLeaderActivate();
                }
                else
                {
                    "Agent is not active".Print(1);
                }
            }
        }
        
    }

    
}