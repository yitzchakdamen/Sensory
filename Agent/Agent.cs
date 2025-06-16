namespace Sensory
{
    class Agent
    {
        public int Id { get; set; }
        public AgentRank Rank { get; set; }
        public Dictionary<SensorType, int> Sensors { get; set; }
        public List<Sensor> ActiveSensors { get; set; } = new();

        public Agent(AgentRank agentRank, Dictionary<SensorType, int> sensors)
        {
            Id = new Random().Next(1,10000);
            Rank = agentRank;
            Sensors = sensors;
            ActiveSensors = new();
        }

    }
    
}