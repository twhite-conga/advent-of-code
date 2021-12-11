

using System.Linq;
using Advent2021.Data.OctopusEnergy;
using Advent2021.Data.Tests.OctopusEnergy;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class EnergyMonitorTests
{
    private readonly ILogger<EnergyMonitor> _logger;
    private readonly int[][] FakeGrid;
    private IOctopusEnergyRepository _repository;

    public EnergyMonitorTests()
    {
        _logger = Substitute.For<ILogger<EnergyMonitor>>();
        _repository =  new OctopusEnergyRepository();
        FakeGrid = _repository.ParseGrid(OctopusEnergyRepositoryTests.FakeGridData);
    }

    [Fact]
    public void Step_Updates_Grid()
    {
        var subject = new EnergyMonitor(_logger);
        var expectedGrid = _repository.ParseGrid(@"6594254334
3856965822
6375667284
7252447257
7468496589
5278635756
3287952832
7993992245
5957959665
6394862637");

        var actual = subject.Step(FakeGrid);

        actual.First().First().Should().Be(expectedGrid.First().First());
        actual[4][4].Should().Be(expectedGrid[4][4]);
        actual.Last().Last().Should().Be(expectedGrid.Last().Last());
    }

    [Fact]
    public void StepTwice_Updates_Grid()
    {
        var subject = new EnergyMonitor(_logger);
        var expectedGrid = _repository.ParseGrid(@"8807476555
5089087054
8597889608
8485769600
8700908800
6600088989
6800005943
0000007456
9000000876
8700006848");
        var first = subject.Step(FakeGrid);

        var actual = subject.Step(first);

        actual.First().First().Should().Be(expectedGrid.First().First());
        actual[4][4].Should().Be(expectedGrid[4][4]);
        actual.Last().Last().Should().Be(expectedGrid.Last().Last());
    }

    [Theory]
    [InlineData(2, 35)]
    [InlineData(10, 204)]
    [InlineData(100, 1656)]
    public void GetTotalFlashes_Gets_Flashes(int count, int expected)
    {
        var subject = new EnergyMonitor(_logger);

        var actual = subject.GetTotalFlashes(FakeGrid, count);

        actual.Should().Be(expected);
    }
}
