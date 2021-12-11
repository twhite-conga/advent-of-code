namespace Advent2021.SubmarineSystems;

public class EnergyMonitor
{
    private readonly ILogger<EnergyMonitor> _logger;

    public EnergyMonitor(ILogger<EnergyMonitor> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetTotalFlashes(int[][] grid)
    {
        var answer = 0;
        _logger.LogCritical("How many total flashes are there after 100 steps? Answer: {Answer}", answer);
        return answer;
    }
}
