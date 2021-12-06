namespace Advent2021.SubmarineSystems;

public class LanternFishCalculator
{
    private readonly ILogger<LanternFishCalculator> _logger;

    public LanternFishCalculator(ILogger<LanternFishCalculator> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int CalculatePopulation(int growthDays)
    {
        int answer = 0;
        _logger.LogCritical("How many lanternfish would there be after {GrowthDays} days? Answer: {Answer}", growthDays,
            answer);
        return answer;
    }
}
