using Advent2021.Data.Models;

namespace Advent2021.Tests;

public class NavigationTests
{
    private readonly ILogger<Navigation> _logger;

    private static List<NavPoint> FakeNavPoints = new List<NavPoint>
    {
        new NavPoint { Direction = Navigation.Forward, Distance = 5 },
        new NavPoint{ Direction = Navigation.Down, Distance = 5 },
        new NavPoint{ Direction = Navigation.Forward, Distance = 8 },
        new NavPoint { Direction = Navigation.Up, Distance = 3 },
        new NavPoint { Direction = Navigation.Down, Distance = 8},
        new NavPoint { Direction = Navigation.Forward, Distance = 2}
    };

    public NavigationTests()
    {
        _logger = Substitute.For<ILogger<Navigation>>();
    }

    [Fact]
    public void MultiplyHorizontalDepthPositions_Multiplies_Final_Position()
    {
        var subject = new Navigation(_logger);

        var actual = subject.MultiplyHorizontalDepthPositions(FakeNavPoints);

        actual.Should().Be(150);
    }

    [Fact]
    public void MultiplyHorizontalDepthPositionsWithAim_Multiplies_Final_Position()
    {
        var subject = new Navigation(_logger);

        var actual = subject.MultiplyHorizontalDepthPositionsWithAim(FakeNavPoints);

        actual.Should().Be(900);
    }
}
