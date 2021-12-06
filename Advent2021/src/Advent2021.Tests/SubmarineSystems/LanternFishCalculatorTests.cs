using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class LanternFishCalculatorTests
{
    private readonly ILogger<LanternFishCalculator> _logger;

    public LanternFishCalculatorTests()
    {
        _logger = Substitute.For<ILogger<LanternFishCalculator>>();
    }

    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    public void CalculatePopulation_Calculates_Population(int growthDays, int expectedPopulation)
    {
        var subject = new LanternFishCalculator(_logger);

        var actual = subject.CalculatePopulation(growthDays);

        actual.Should().Be(expectedPopulation);
    }
}
