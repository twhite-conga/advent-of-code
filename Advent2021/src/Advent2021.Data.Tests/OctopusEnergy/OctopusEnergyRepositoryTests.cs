using Advent2021.Data.OctopusEnergy;

namespace Advent2021.Data.Tests.OctopusEnergy;

public class OctopusEnergyRepositoryTests
{
    public const string FakeGridData = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    [Fact]
    public void ParseGrid_Parses_Grid()
    {
        var subject = new OctopusEnergyRepository();

        var actual = subject.ParseGrid(FakeGridData);

        actual.First().First().Should().Be(5);
        actual.Last().Last().Should().Be(6);
    }
}
