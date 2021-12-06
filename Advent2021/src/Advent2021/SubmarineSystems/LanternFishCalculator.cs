using Advent2021.Data.LanternFish;

namespace Advent2021.SubmarineSystems;

public class LanternFishCalculator
{
    private readonly ILogger<LanternFishCalculator> _logger;

    public LanternFishCalculator(ILogger<LanternFishCalculator> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public long CalculatePopulation(int growthDays, List<LanternFish> population)
    {
        var ageCounts = SortAges(population);
        ageCounts = GrowPopulation(growthDays, ageCounts);
        long answer = ageCounts.Sum();
        _logger.LogCritical("How many lanternfish would there be after {GrowthDays} days? Answer: {Answer}", growthDays,
            answer);
        return answer;
    }

    private long[] GrowPopulation(int growthDays, long[] ageCounts)
    {
        for (var i = 0; i < growthDays; i++)
        {
            var mamas = ageCounts[0];
            LeftShiftArray(ageCounts, 1);
            ageCounts[6] += mamas;
        }

        return ageCounts;
    }

    public long[] SortAges(List<LanternFish> population)
    {
        var ageCounts = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (var i = 0; i < ageCounts.Length; i++)
        {
            ageCounts[i] = population.Count(f => f.GestationDaysLeft == i);
        }
        return ageCounts;
    }

    public static void LeftShiftArray<T>(T[] arr, int shift)
    {
        shift %= arr.Length;
        var buffer = new T[shift];
        Array.Copy(arr, buffer, shift);
        Array.Copy(arr, shift, arr, 0, arr.Length - shift);
        Array.Copy(buffer, 0, arr, arr.Length - shift, shift);
    }
}
