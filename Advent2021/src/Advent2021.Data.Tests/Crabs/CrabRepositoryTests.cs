using Advent2021.Data.Crabs;

namespace Advent2021.Data.Tests.Crabs;

public class CrabRepositoryTests
{
    public const string FakeCrabPositions = @"16,1,2,0,4,2,7,1,2,14";

    [Fact]
    public void ParseCrabs_Parses()
    {
        var subject = new CrabRepository();

        var actual = subject.ParsePositions(FakeCrabPositions);

        actual.First().Should().Be(16);
        actual.Last().Should().Be(14);
    }
}
