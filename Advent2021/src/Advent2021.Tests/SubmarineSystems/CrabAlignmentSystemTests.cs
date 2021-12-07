using Advent2021.Data.Crabs;
using Advent2021.Data.Tests.Crabs;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class CrabAlignmentSystemTests
{
    private readonly ILogger<CrabAlignmentSystem> _logger;

    private readonly List<Crab> _fakeCrabs;

    public CrabAlignmentSystemTests()
    {
        _logger = Substitute.For<ILogger<CrabAlignmentSystem>>();
        var respository = new CrabRepository();
        _fakeCrabs = respository.ParseCrabs(CrabRepositoryTests.FakeCrabPositions);
    }

    [Fact]
    public void GetCheapestAlignmentFuelCost_Returns_Cost()
    {
        var subject = new CrabAlignmentSystem(_logger);

        var actual = subject.GetCheapestAlignmentFuelCost(_fakeCrabs);

        actual.Should().Be(37);
    }
}
