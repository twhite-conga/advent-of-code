namespace Advent2021.Data.SensorFix;

public class SensorFixRepository : ISensorFixRepository
{
    public List<SensorReading> ParseReadings(string data)
    {
        var sensorReadings = new List<SensorReading>();
        var rawReadings = data.Split(Environment.NewLine).ToList();
        foreach (var rawSensorReading in rawReadings)
        {
            var lists = rawSensorReading.Split("|");
            var signalPatterns = lists.First().Split(" ").Where(o => !string.IsNullOrEmpty(o)).ToList();
            var output = lists.Last().Split(" ").Where(o => !string.IsNullOrEmpty(o)).ToList();
            sensorReadings.Add(new SensorReading
            {
                SignalPatterns = signalPatterns,
                Output = output
            });
        }

        return sensorReadings;
    }
}
