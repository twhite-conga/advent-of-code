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
}
