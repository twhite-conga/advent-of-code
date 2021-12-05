namespace Advent2021.SubmarineSystems;

public class SonarSweep
{
    private readonly ILogger<SonarSweep> _logger;

    public SonarSweep(ILogger<SonarSweep> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetDepthMeasurementIncreaseRate(List<int> depthMeasurements)
    {
        var increases = GetIncreaseRate(depthMeasurements);
        _logger.LogCritical("How many measurements are larger than the previous measurement? Answer: {Increases}",
            increases);
        return increases;
    }

    private static int GetIncreaseRate(List<int> measurements)
    {
        var increases = 0;
        for (var i = 1; i < measurements.Count; i++)
        {
            var measurement = measurements[i];
            var previousMeasurement = measurements[i - 1];
            if (measurement > previousMeasurement) increases++;
        }

        return increases;
    }

    public int GetSlidingWindowSums(List<int> depthMeasurements)
    {
        var sums = new List<int>();
        for (var i = 0; i + 2 < depthMeasurements.Count; i++)
        {
            var sum = depthMeasurements[i] + depthMeasurements[i + 1] + depthMeasurements[i + 2];
            sums.Add(sum);
        }

        var increases = GetIncreaseRate(sums);

        _logger.LogCritical("How many sums are larger than the previous sum? Answer: {Sums}",
            increases);
        return increases;
    }
}
