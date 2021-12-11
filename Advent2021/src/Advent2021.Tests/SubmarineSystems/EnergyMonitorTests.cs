using Advent2021.Data.OctopusEnergy;
using Advent2021.Data.Tests.OctopusEnergy;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class EnergyMonitorTests
{
    private readonly ILogger<EnergyMonitor> _logger;
    private readonly int[][] FakeGrid;

    public EnergyMonitorTests()
    {
        _logger = Substitute.For<ILogger<EnergyMonitor>>();
        var repository = new OctopusEnergyRepository();
        FakeGrid = repository.ParseGrid(OctopusEnergyRepositoryTests.FakeGridData);
    }

    [Fact]
    public void GetTotalFlashes_Gets_Flashes()
    {
        var subject = new EnergyMonitor(_logger);

        var actual = subject.GetTotalFlashes(FakeGrid);

        actual.Should().Be(1656);
    }
}
