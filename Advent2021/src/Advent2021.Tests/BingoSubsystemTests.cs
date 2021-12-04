using Advent2021.Data.Models;

namespace Advent2021.Tests;

public class BingoSubsystemTests
{
    private readonly ILogger<BingoSubsystem> _logger;

    private BingoDataSet FakeBingoDataSet = new();

    public BingoSubsystemTests()
    {
        _logger = Substitute.For<ILogger<BingoSubsystem>>();
    }

    [Fact]
    public void CalculateWinnerScore_Calculates_Score()
    {
        var subject = new BingoSubsystem(_logger);

        var actual = subject.CalculateWinnerScore(FakeBingoDataSet);

        actual.Should().Be(4512);
    }
}
