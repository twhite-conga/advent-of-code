using Advent2021.Data;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class SyntaxCheckerTests
{
    private const string RawSyntaxData = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

    private static List<string> FakeSyntaxData;

    private readonly ILogger<SyntaxChecker> _logger;

    public SyntaxCheckerTests()
    {
        _logger = Substitute.For<ILogger<SyntaxChecker>>();
        var repository = new RawDataService();
        FakeSyntaxData = repository.ParseRawData(RawSyntaxData);
    }

    [Fact]
    public void GetSyntaxErrorScore_Returns_Score()
    {
        var subject = new SyntaxChecker(_logger);

        var actual = subject.GetSyntaxErrorScore(FakeSyntaxData);

        actual.Should().Be(26397);
    }
}
