namespace Sensory
{
    public static class AgentFactory
    {
        public static Agent Agent(AgentRank agentRank)
        {
            return agentRank switch
            {
                AgentRank.Zutar => new GamePropertyAgents.RegularAgent(),
                AgentRank.SquadLeader => new GamePropertyAgents.SquadLeaderAgent(),
                AgentRank.SeniorCommander => new GamePropertyAgents.SeniorCommander(),
                AgentRank.OrganizationLeader => new GamePropertyAgents.OrganizationLeader(),
                _ => new GamePropertyAgents.RegularAgent(),
            };
        }
    }
    
}