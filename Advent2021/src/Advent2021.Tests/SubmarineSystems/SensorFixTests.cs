using System.Linq;
using Advent2021.Data.SensorFix;
using Advent2021.Data.Tests.SensorFix;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class SensorFixTests
{
    private readonly ILogger<SensorFix> _logger;

    private static List<SensorReading> _fakeSensorReadings;

    public SensorFixTests()
    {
        _logger = Substitute.For<ILogger<SensorFix>>();
        var repository = new SensorFixRepository();
        _fakeSensorReadings = repository.ParseReadings(SensorFixRepositoryTests.FakeRawReadings);
    }

    [Fact]
    public void CheckForKnowDigits_Checks_Digits()
    {
        var subject = new SensorFix(_logger);

        var actual = subject.CheckForKnowDigits(_fakeSensorReadings);

        actual.Should().Be(26);
    }

    [Fact]
    public void AddAllOutputValues_Adds_All_Readings()
    {
        var subject = new SensorFix(_logger);

        var actual = subject.AddAllOutputValues(_fakeSensorReadings);

        actual.Should().Be(61229);
    }

    [Fact]
    public void MapAllSignals_Maps_Signals()
    {
        var subject = new SensorFix(_logger);
        var expectedSignals = new string[]
            { "cagedb", "ab", "gcdfa", "fbcad", "eafb", "cdfbe", "cdfgeb", "dab", "acedgfb", "cefabd" };
        var repository = new SensorFixRepository();
        var fakeReadings = repository.ParseReadings(
            "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");

        var actual = subject.MapAllSignals(fakeReadings.FirstOrDefault());

        for (var i = 0; i < actual.Length; i++)
        {
            actual[i].Should().Be(expectedSignals[i]);
        }
    }
}
