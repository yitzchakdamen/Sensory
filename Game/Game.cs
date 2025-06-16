using System.Text.RegularExpressions;

namespace Sensory
{


    class Game
    {
        public List<Agent> AgentsGame = new();

        public void AddGameAgent()
        {
            Sensor sensorA = Sensor.AddSensor(SensorType.Motion);
            Sensor sensorC = Sensor.AddSensor(SensorType.Visual);
            Sensor sensorB = Sensor.AddSensor(SensorType.Thermal);

            List<Sensor> ActiveSensors = new() { sensorA, sensorB, sensorC };
            Dictionary<SensorType, int> Sensors = new() { { SensorType.Motion, 5 }, { SensorType.Thermal, 1 } };

            Agent agent = Agent.AddAgent(AgentRank.Zutar, Sensors, ActiveSensors);
            AgentsGame.Add(agent);
        }

        public bool Checker()
        {
            bool Victory = true;
            foreach (Agent agent in AgentsGame)
            {
                if (!CheckerAgent(agent.ActiveSensors, agent.Sensors))
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
                    {
                        QuantityActual += QuantityActiveSensors;
                    }
                    else
                    {
                        QuantityActual += QuantitySensor;
                    }
                    QuantityRequired += QuantitySensor;
                }
            }

            Console.WriteLine($"QuantityActual: {QuantityActual}, QuantityRequired: {QuantityRequired}");

            if (QuantityActual < QuantityRequired)
            {
                return false;
            }
            return true;

        }

        public void ActiveSensors(Agent agent)
        {
            foreach (Sensor Sensors in agent.ActiveSensors)
            {
                Sensors.Active();
            }
        }
        
    }

    
}