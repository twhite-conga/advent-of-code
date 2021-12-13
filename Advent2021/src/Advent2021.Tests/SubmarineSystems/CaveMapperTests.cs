using Advent2021.Data;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class CaveMapperTests
{
    private readonly ILogger<CaveMapper> _logger;
    private readonly IRawDataService _rawDataService;

    private const string FakePathData1 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

    private const string FakePathData2 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

    private const string FakePathData3 = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    public CaveMapperTests()
    {
        _logger = Substitute.For<ILogger<CaveMapper>>();
        _rawDataService = Substitute.For<IRawDataService>();
        _rawDataService = new RawDataService();
    }

    [Theory]
    [InlineData(FakePathData1, 19)]
    [InlineData(FakePathData2, 226)]
    [InlineData(FakePathData3, 10)]
    public void GetPathsThroughCave_Gets_Paths(string pathData, int expected)
    {
        var subject = new CaveMapper(_logger);
        var paths = _rawDataService.ParseRawData(pathData);

        var actual = subject.GetPathsThroughCave(paths);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(FakePathData1, 103)]
    public void GetPathsThroughCaveSmallCavesTwice_Gets_Paths(string pathData, int expected)
    {
        var subject = new CaveMapper(_logger);
        var paths = _rawDataService.ParseRawData(pathData);

        var actual = subject.GetPathsThroughCaveSmallCavesTwice(paths);

        actual.Should().Be(expected);
    }
}
