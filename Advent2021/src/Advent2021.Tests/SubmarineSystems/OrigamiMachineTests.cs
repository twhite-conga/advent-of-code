using Advent2021.Data.Origami;
using Advent2021.Data.Tests.Origami;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class OrigamiMachineTests
{
    private readonly ILogger<OrigamiMachine> _logger;

    private static OrigamiInstruction FakeOrigamiInstruction;

    public OrigamiMachineTests()
    {
        _logger = Substitute.For<ILogger<OrigamiMachine>>();
        var repository = new OrigamiRepository();
        FakeOrigamiInstruction = repository.ParseInstructions(OrigamiRepositoryTests.FakeOrigamiInstructions);
    }

    [Fact]
    public void GetVisibleDotsAfterFirstFold_Gets_Dot_Count()
    {
        var subject = new OrigamiMachine(_logger);

        var actual = subject.GetVisibleDotsAfterFirstFold(FakeOrigamiInstruction);

        actual.Should().Be(17);
    }
}
