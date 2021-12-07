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
        var costs = GetAlignmentCost(positions);
        var answer = costs.Min();
        _logger.LogCritical("How much fuel must they spend to align to that position? Answer: {Answer}", answer);
        return answer;
    }

    private static IEnumerable<int> GetAlignmentCost(IReadOnlyCollection<int> positions)
    {
        var max = positions.Max();
        var fuelCosts = new List<int>();
        for (var i = 1; i <= max; i++)
        {
            fuelCosts.Add(GetCost(i, positions));
        }

        return fuelCosts;
    }

    private static int GetCost(int i, IEnumerable<int> positions)
    {
        return positions.Sum(position => Math.Abs(position - i));
    }
}
