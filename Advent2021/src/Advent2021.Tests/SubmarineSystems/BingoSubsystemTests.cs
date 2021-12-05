using Advent2021.Data;
using Advent2021.Data.Models;
using Advent2021.Data.Tests;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class BingoSubsystemTests
{
    private readonly ILogger<BingoSubsystem> _logger;

    private readonly BingoDataSet _fakeBingoDataSet;

    public BingoSubsystemTests()
    {
        _logger = Substitute.For<ILogger<BingoSubsystem>>();
        var rawDataParser = new RawDataService();
        _fakeBingoDataSet = rawDataParser.ParseRawBingoData(RawDataServiceTests.FakeBingoData);
    }

    [Fact]
    public void CalculateFirstWinningBoardScore_Calculates_Score()
    {
        var subject = new BingoSubsystem(_logger);

        var actual = subject.CalculateFirstWinningBoardScore(_fakeBingoDataSet);

        actual.Should().Be(4512);
    }

    [Fact]
    public void CalculateLastWinningBoardScore_Calculates_Score()
    {
        var subject = new BingoSubsystem(_logger);

        var actual = subject.CalculateLastWinningBoardScore(_fakeBingoDataSet);

        actual.Should().Be(1924);
    }
}
