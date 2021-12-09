using Advent2021.Data.SensorFix;

namespace Advent2021.SubmarineSystems;

public class SensorFix
{
    private readonly ILogger<SensorFix> _logger;

    public SensorFix(ILogger<SensorFix> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int CheckForKnowDigits(List<SensorReading> sensorReadings)
    {
        var answer = CheckSensorReadings(sensorReadings);
        _logger.LogCritical("In the output values, how many times do digits 1, 4, 7, or 8 appear? Answer: {Answer}",
            answer);
        return answer;
    }


    private int CheckSensorReadings(List<SensorReading> sensorReadings)
    {
        var counter = 0;
        foreach (var sensorReading in sensorReadings)
        {
            counter += CheckReading(sensorReading);
        }

        return counter;
    }

    private const int OneLength = 2;
    private const int FourLength = 4;
    private const int SevenLength = 3;
    private const int EightLength = 7;

    private int CheckReading(SensorReading sensorReading)
    {
        var onSignals = new Dictionary<int, string>
        {
            { OneLength, null },
            { FourLength, null },
            { SevenLength, null },
            { EightLength, null }
        };
        foreach (var (key, value) in onSignals)
        {
            onSignals[key] = sensorReading.SignalPatterns.FirstOrDefault(sp => sp.Length == key);
        }

        return sensorReading.Output.Sum(output =>
            onSignals.Count(onSignal => output.Length == onSignal.Key && output.All(c => onSignal.Value.Contains(c))));
    }
}
