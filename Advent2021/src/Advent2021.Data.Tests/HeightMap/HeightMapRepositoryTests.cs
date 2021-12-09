using Advent2021.Data.HeighMap;

namespace Advent2021.Data.Tests.HeightMap;

public class HeightMapRepositoryTests
{
    public const string FakeRawHeightMapData = @"2199943210
3987894921
9856789892
8767896789
9899965678";

    [Fact]
    public void ParseHeightMap_Parses_Map()
    {
        var subject = new HeightMapRepository();

        var actual = subject.ParseHeightMap(FakeRawHeightMapData);

        actual.First().First().Should().Be(2);
        actual.Last().Last().Should().Be(8);
    }
}
