using Advent2021.Data;
using Advent2021.Data.Models;
using Advent2021.Data.Tests;

namespace Advent2021.Tests;

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
    public void CalculateWinnerScore_Calculates_Score()
    {
        var subject = new BingoSubsystem(_logger);

        var actual = subject.CalculateWinnerScore(_fakeBingoDataSet);

        actual.Should().Be(4512);
    }
}
