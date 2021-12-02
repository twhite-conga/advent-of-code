namespace Advent2021.Tests;

public class SonarSweepTests
{
    private readonly ILogger<SonarSweep> _logger;

    public static readonly List<int> FakeDepthMeasurements = new()
    {
        199, 200, 208, 210, 200,207, 240, 269, 260, 263
    };

    public SonarSweepTests()
    {
        _logger = Substitute.For<ILogger<SonarSweep>>();
    }

    [Fact]
    public void GetDepthMeasurementIncreaseRate_Counts_Increases()
    {
        var subject = new SonarSweep(_logger);

        var actual = subject.GetDepthMeasurementIncreaseRate(FakeDepthMeasurements);

        actual.Should().Be(7);
    }

    [Fact]
    public void GetSlidingWindowSums_Counts_Sums()
    {
        var subject = new SonarSweep(_logger);

        var actual = subject.GetSlidingWindowSums(FakeDepthMeasurements);

        actual.Should().Be(5);
    }
}
