namespace Sensory
{
    public class Sensor
    {
        public int Id { get; set; } = 4;
        public SensorType Type { get; set; }
        public int SensorStatus = 0;

        public Sensor(SensorType sensorType)
        {
            Id = new Random().Next(1, 10000);
            Type = sensorType;
        }

        public void Active()
        {
            SensorStatus++;
            $"Sensor {Id} {Type} ----  is Active    -----    num of times: {SensorStatus}".Print(2);
        }

        public virtual void UniqueAction(Agent agent)
        {
            Console.WriteLine(" ============== Unique Action ==============");
        }
        
    }
    
}