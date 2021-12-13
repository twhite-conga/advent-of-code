using Advent2021.Data.Origami;

namespace Advent2021.Data.Tests.Origami;

public class OrigamiRepositoryTests
{
    public const string FakeOrigamiInstructions = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

    [Fact]
    public void ParseInstructions_Parses_Instructions()
    {
        var subject = new OrigamiRepository();

        var actual = subject.ParseInstructions(FakeOrigamiInstructions);

        actual.Coordinates.First().X.Should().Be(6);
        actual.Coordinates.First().Y.Should().Be(10);
        actual.Coordinates.Last().X.Should().Be(9);
        actual.Coordinates.Last().Y.Should().Be(0);
        actual.Folds.Last().Direction.Should().Be(Fold.X);
        actual.Folds.Last().Distance.Should().Be(5);
    }
}
