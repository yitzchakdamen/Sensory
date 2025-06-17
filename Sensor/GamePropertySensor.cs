namespace Sensory
{
    static class GamePropertySensor
    {
        public class Pulse : Sensor
        {
            public Pulse() : base(SensorType.Pulse) { }
            public override void UniqueAction(Agent agent)
            {
                if (SensorStatus >= 3)
                {
                    PrintMenu.LogPulseSensor(agent, SensorStatus);
                    agent.ActiveSensors.Remove(this);
                }
            }
        }

        public class Motion : Sensor
        {
            public Motion() : base(SensorType.Motion) { }
            public override void UniqueAction(Agent agent)
            {
                if (SensorStatus >= 3)
                {
                    PrintMenu.LogMotionSensor(agent, SensorStatus);
                    agent.ActiveSensors.Remove(this);
                }
            }
        }

        public class Thermal : Sensor
        {
            public Thermal() : base(SensorType.Thermal) { }
            public override void UniqueAction(Agent agent)
            {
                Random rnd = new();
                var keys = agent.Sensors.Keys.ToList();
                var randomSensor = keys[rnd.Next(0, keys.Count)];
                PrintMenu.LogThermalSensor(agent, randomSensor);
            }
        }

        public class Cellular : Sensor
        {
            public Cellular() : base(SensorType.Cellular) { }
            public override void UniqueAction(Agent agent)
            {
                PrintMenu.LogCellularSensor(agent);
            }
        }

        public class Audio : Sensor
        {
            public Audio() : base(SensorType.Audio) { }
            // עדיין אין פעולה מיוחדת
        }

        public class Visual : Sensor
        {
            public Visual() : base(SensorType.Visual) { }
            public override void UniqueAction(Agent agent)
            {
                PrintMenu.LogVisualSensor(agent);
            }
        }
    }
}
