namespace Sensory
{
    public static class SensorFactory
    {
        public static Sensor Sensor(SensorType sensorType)
        {
            return sensorType switch
            {
                SensorType.Motion => new GamePropertySensor.Motion(),
                SensorType.Thermal => new GamePropertySensor.Thermal(),
                SensorType.Cellular => new GamePropertySensor.Cellular(),
                SensorType.Audio => new GamePropertySensor.Audio(),
                SensorType.Visual => new GamePropertySensor.Visual(),
                SensorType.Pulse => new GamePropertySensor.Pulse(),
                _ => new GamePropertySensor.Audio(),
            };
        }
    }
    
}