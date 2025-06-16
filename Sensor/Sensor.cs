namespace Sensory
{
    class Sensor
    {
        public int Id { get; set; } = 4;
        public SensorType Type { get; set; } = SensorType.Thermal;
        public int SensorStatus = 0;

        static public Sensor AddSensor(SensorType sensorType)
        {
            Sensor sensor = new();
            sensor.Id = new Random().Next(1,10000);
            sensor.Type = sensorType;
            return sensor;
        }

        public void Active()
        {
            SensorStatus++;
            Console.WriteLine($"Sensor {Id} {Type} is Active: num of times: {SensorStatus}");
        }
        
    }
    
}