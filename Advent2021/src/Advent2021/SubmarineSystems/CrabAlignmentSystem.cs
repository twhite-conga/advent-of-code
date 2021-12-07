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

    public int GetCheapestAlignmentIncreasingFuelCost(List<int> positions)
    {
        var costs = GetAlignmentCost(positions, true);
        var answer = costs.Min();
        _logger.LogCritical("How much (increasing) fuel must they spend to align to that position? Answer: {Answer}", answer);
        return answer;
    }

    private static IEnumerable<int> GetAlignmentCost(IReadOnlyCollection<int> positions, bool useIncreasing = false)
    {
        var max = positions.Max();
        var fuelCosts = new List<int>();
        for (var i = 1; i <= max; i++)
        {
            var cost = useIncreasing ? GetIncreasingCost(i, positions) : GetCost(i, positions);
            fuelCosts.Add(cost);
        }

        return fuelCosts;
    }

    private static int GetIncreasingCost(int i, IReadOnlyCollection<int> positions)
    {
        return positions.Sum(positon =>
        {
            var total = 0;
            var distance = Math.Abs(positon - i);
            for (var j = 1; j <= distance; j++)
            {
                total += j;
            }
            return total;
        });
    }

    private static int GetCost(int i, IEnumerable<int> positions)
    {
        return positions.Sum(position => Math.Abs(position - i));
    }
}
