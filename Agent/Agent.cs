namespace Sensory
{
    class Agent
    {
        public int Id { get; set; }
        public AgentRank Rank { get; set; }
        public Dictionary<SensorType, int> Sensors { get; set; }
        public List<Sensor> ActiveSensors { get; set; } = new();

        static public Agent AddAgent(AgentRank agentRank, Dictionary<SensorType, int> sensors, List<Sensor> activeSensors)
        {
            Agent agent = new();
            agent.Id = new Random().Next(1,10000);
            agent.Rank = agentRank;
            agent.Sensors = sensors;
            agent.ActiveSensors = activeSensors;
            return agent;
        }

    }
    
    
}