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
        population = GrowPopulation(growthDays, population);
        var answer = population.Count;
        _logger.LogCritical("How many lanternfish would there be after {GrowthDays} days? Answer: {Answer}", growthDays,
            answer);
        return answer;
    }

    public List<LanternFish> GrowPopulation(int growthDays, List<LanternFish> population)
    {
        for (var i = 0; i < growthDays; i++)
        {
            var babyFishes = new List<LanternFish>();
            foreach (var fish in population)
            {
                var itsAGirl = UpdateFish(fish);
                if (itsAGirl) babyFishes.Add(new LanternFish());
            }
            population = population.Concat(babyFishes).ToList();
        }

        return population;
    }

    private bool UpdateFish(LanternFish fish)
    {
        if (fish.GestationDaysLeft == 0)
        {
            fish.GestationDaysLeft = 6;
            return true;
        }
        fish.GestationDaysLeft--;
        return false;
    }
}
