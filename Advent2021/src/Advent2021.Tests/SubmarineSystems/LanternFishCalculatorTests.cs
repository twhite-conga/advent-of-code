using Advent2021.Data.LanternFish;
using Advent2021.Data.Tests.LanternFish;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class LanternFishCalculatorTests
{
    private readonly ILogger<LanternFishCalculator> _logger;
    private readonly List<LanternFish> _fakeLanternFishes;

    public LanternFishCalculatorTests()
    {
        _logger = Substitute.For<ILogger<LanternFishCalculator>>();
        var repository = new LanternFishRepository();
        _fakeLanternFishes = repository.GetAll(LanternFishRepositoryTests.FakeLanternFishData);
    }

    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    // [InlineData(256, 26984457539)]
    public void CalculatePopulation_Calculates_Population(int growthDays, long expectedPopulation)
    {
        var subject = new LanternFishCalculator(_logger);

        var actual = subject.CalculatePopulation(growthDays, _fakeLanternFishes);

        actual.Should().Be(expectedPopulation);
    }
}
