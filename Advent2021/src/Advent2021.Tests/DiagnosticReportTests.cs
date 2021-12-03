namespace Advent2021.Tests;

public class DiagnosticReportTests
{
    private readonly ILogger<DiagnosticReport> _logger;

    private static List<string> _fakeBinaryInputs = new List<string>
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    };

    public DiagnosticReportTests()
    {
        _logger = Substitute.For<ILogger<DiagnosticReport>>();
    }

    [Fact]
    public void GetPowerConsumption_Returns_PowerConsumption()
    {
        var subject = new DiagnosticReport(_logger);

        var actual = subject.GetPowerConsumption(_fakeBinaryInputs);

        actual.Should().Be(198);
    }

    [Fact]
    public void GetLifeSupportRating_Returns_PowerConsumption()
    {
        var subject = new DiagnosticReport(_logger);

        var actual = subject.GetLifeSupportRating(_fakeBinaryInputs);

        actual.Should().Be(230);
    }
}
