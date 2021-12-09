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
        var answer = CheckKnownSensorReadings(sensorReadings);
        _logger.LogCritical("In the output values, how many times do digits 1, 4, 7, or 8 appear? Answer: {Answer}",
            answer);
        return answer;
    }

    public double AddAllOutputValues(List<SensorReading> sensorReadings)
    {
        var readings = CheckAllSensorReadings(sensorReadings);
        var answer = readings.Sum();
        _logger.LogCritical("What do you get if you add up all of the output values? Answer: {Answer}",
            answer);
        return answer;
    }

    private List<double> CheckAllSensorReadings(List<SensorReading> sensorReadings)
    {
        var outputs = new List<double>();
        foreach (var sensorReading in sensorReadings)
        {
            var completeSignalMap = MapAllSignals(sensorReading);
            var outputValues = GetAllOutputValues(sensorReading.Output, completeSignalMap);
            outputValues.Reverse();
            double output = 0;
            for (var i = 0; i < outputValues.Count; i++)
            {
                output += outputValues[i] * Math.Pow(10, i);
            }

            outputs.Add(output);
        }

        return outputs;
    }

    private List<int> GetAllOutputValues(List<string> sensorReadingOutput, string[] completeSignalMap)
    {
        var outputValues = new List<int>();
        foreach (var output in sensorReadingOutput)
        {
            outputValues.Add(Array.FindIndex(completeSignalMap, s => HaveSameLetters(s, output)));
        }

        return outputValues;
    }

    private bool HaveSameLetters(string a, string b)
    {
        return a.All(x => b.Contains(x)) && b.All(x => a.Contains(x));
    }

    public string[] MapAllSignals(SensorReading sensorReading)
    {
        var knownSignalMap = MapKnownSignals(sensorReading);
        var signals = new string[10];
        signals[1] = knownSignalMap[OneLength];
        signals[4] = knownSignalMap[FourLength];
        signals[7] = knownSignalMap[SevenLength];
        signals[8] = knownSignalMap[EightLength];
        var remainingSignals = GetRemainingSignals(sensorReading, signals);
        signals[3] =
            remainingSignals.First(s => s.Length == 5 && s.Contains(signals[1][0]) && s.Contains(signals[1][1]));
        remainingSignals = GetRemainingSignals(sensorReading, signals);
        signals[6] =
            remainingSignals.First(s => s.Length == 6 && !(s.Contains(signals[1][0]) && s.Contains(signals[1][1])));
        remainingSignals = GetRemainingSignals(sensorReading, signals);
        signals[9] = remainingSignals.First(s => s.Length == 6 && signals[4].All(s.Contains));
        remainingSignals = GetRemainingSignals(sensorReading, signals);
        signals[0] = remainingSignals.First(s => s.Length == 6);
        remainingSignals = GetRemainingSignals(sensorReading, signals);
        signals[5] = remainingSignals.First(s => s.Length == 5 && s.All(signals[9].Contains));
        remainingSignals = GetRemainingSignals(sensorReading, signals);
        signals[2] = remainingSignals.First();
        return signals;
    }

    private static List<string> GetRemainingSignals(SensorReading sensorReading, string[] signals)
    {
        var remainingSignals = sensorReading.SignalPatterns.Where(sp => !signals.Contains(sp)).ToList();
        return remainingSignals;
    }


    private int CheckKnownSensorReadings(List<SensorReading> sensorReadings)
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
        var onSignals = MapKnownSignals(sensorReading);

        return sensorReading.Output.Sum(output =>
            onSignals.Count(onSignal => output.Length == onSignal.Key && output.All(c => onSignal.Value.Contains(c))));
    }

    private static Dictionary<int, string> MapKnownSignals(SensorReading sensorReading)
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

        return onSignals;
    }
}
