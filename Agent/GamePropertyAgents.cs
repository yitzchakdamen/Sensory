namespace Sensory
{
    static class GamePropertyAgents
    {
        class RegularAgent : Agent
        {
            public RegularAgent() : base(AgentRank.Zutar, GenerateSensors(2)) { }
        }


        class SquadLeaderAgent : Agent
        {
            public SquadLeaderAgent() : base(AgentRank.SquadLeader, GenerateSensors(5)) { }
            public void Activate()
            {
                ActiveSensors.RemoveAt(new Random().Next(0, ActiveSensors.Count));
                Console.WriteLine($"Agent {Id} {Rank} is active. sensors: {ActiveSensors.Count}");
            }

        }

        private static Dictionary<SensorType, int> GenerateSensors(int quantity)
        {
            var rnd = new Random();
            Dictionary<SensorType, int> sensors = new();

            while (sensors.Values.Sum() <= quantity)
            {
                SensorType sensorType = (SensorType)rnd.Next(1, 6);
                int Value = rnd.Next(1, quantity - sensors.Values.Sum());

                if (!sensors.TryGetValue(sensorType, out int _))
                {
                    sensors.Add(sensorType, Value);
                }
            }
            return sensors;
        }
            
    }
}