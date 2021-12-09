using Advent2021.Data.HeighMap;
using Advent2021.Data.Tests.HeightMap;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class HeightMapSensorTests
{
    private readonly ILogger<HeightMapSensor> _logger;
    private int[][] _fakeHeightMap;

    public HeightMapSensorTests()
    {
        _logger = Substitute.For<ILogger<HeightMapSensor>>();
        var repository = new HeightMapRepository();
        _fakeHeightMap = repository.ParseHeightMap(HeightMapRepositoryTests.FakeRawHeightMapData);
    }

    [Fact]
    public void SumLowPointRiskLevels_Returns_Sum()
    {
        var subject = new HeightMapSensor(_logger);

        var actual = subject.SumLowPointRiskLevels(_fakeHeightMap);

        actual.Should().Be(15);
    }
}
