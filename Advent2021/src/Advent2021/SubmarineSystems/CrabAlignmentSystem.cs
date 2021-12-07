using Advent2021.Data.Crabs;

namespace Advent2021.SubmarineSystems;

public class CrabAlignmentSystem
{
    private readonly ILogger<CrabAlignmentSystem> _logger;

    public CrabAlignmentSystem(ILogger<CrabAlignmentSystem> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetCheapestAlignmentFuelCost(List<int> positions)
    {
        var answer = 0;
        _logger.LogCritical("How much fuel must they spend to align to that position? Answer: {Answer}", answer);
        return answer;
    }
}
