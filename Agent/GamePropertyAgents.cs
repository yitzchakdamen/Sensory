namespace Sensory
{
    static class GamePropertyAgents
    {
        public class RegularAgent : Agent
        {
            public RegularAgent() : base(AgentRank.Zutar, GenerateSensors(2)) { }
        } 

        public class SquadLeaderAgent : Agent
        {
            public SquadLeaderAgent() : base(AgentRank.SquadLeader, GenerateSensors(4)) { }
            public override void AgentActivate()
            {
                if (ActiveSensors.Count == 0) return;
                ActiveSensors.RemoveAt(new Random().Next(0, ActiveSensors.Count));
                $"Agent {Id} {Rank} is Activate. is remove a sensor".Print(1);
            }

        }
        public class SeniorCommander : Agent
        {
            public SeniorCommander() : base(AgentRank.SeniorCommander, GenerateSensors(6)) { }
            public override void AgentActivate()
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ActiveSensors.Count == 0) break;
                    ActiveSensors.RemoveAt(new Random().Next(0, ActiveSensors.Count));
                }
                $"Agent {Id} {Rank} is Activate. is remove 2 sensor".Print(1);
            }

        }
        public class OrganizationLeader : Agent
        {
            public OrganizationLeader() : base(AgentRank.OrganizationLeader, GenerateSensors(8)) { }
            public override void AgentActivate()
            {
                if (ActiveSensors.Count == 0) return;
                ActiveSensors.RemoveAt(new Random().Next(0, ActiveSensors.Count));
                $"Agent {Id} {Rank} is Activate. is remove a sensor".Print(1);
            }
            public void OrganizationLeaderActivate()
            {
                ActiveSensors.Clear();
                Sensors = GenerateSensors(8);
            }

        }

        private static Dictionary<SensorType, int> GenerateSensors(int quantity)
        {
            var rnd = new Random();
            Dictionary<SensorType, int> sensors = new();

            while (sensors.Values.Sum() < quantity)
            {
                SensorType sensorType = (SensorType)rnd.Next(1, 6);
                int Value = rnd.Next(1, quantity - sensors.Values.Sum() + 1);

                if (!sensors.TryGetValue(sensorType, out int _))
                {
                    sensors.Add(sensorType, Value);
                }
            }
            return sensors;
        }
            
    }
}