using System.Text;

namespace Advent2021.SubmarineSystems;

public class SyntaxChecker
{
    private readonly ILogger<SyntaxChecker> _logger;

    public SyntaxChecker(ILogger<SyntaxChecker> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetSyntaxErrorScore(List<string> syntaxData)
    {
        var scores = new Dictionary<char, int> { { '}', 1197 }, { ')', 3 }, { '>', 25137 }, { ']', 57 }, { '\0', 0 } };
        var corruptedLines = GetCorruptedLines(syntaxData);
        var answer = corruptedLines.Sum(corruptedChar => scores[corruptedChar]);
        _logger.LogCritical("What is the total syntax error score for those errors? Answer: {Answer}", answer);
        return answer;
    }

    private long ScorePart2(string s)
    {
        var values = new Dictionary<char, long> { { '}', 3 }, { ')', 1 }, { '>', 4 }, { ']', 2 } };
        return s.Aggregate(0, (long a, char b) => a * 5 + values[b]);
    }

    public long GetAutoCompleteScore(List<string> syntaxData)
    {
        var scores = syntaxData.Select(CompleteLine)
            .Where(l => l != "error")
            .Select(ScorePart2)
            .OrderBy(s => s).ToList();
        var answer = scores[scores.Count / 2];
        _logger.LogCritical("What is the middle score? Answer: {Answer}", answer);
        return answer;
    }

    private string CompleteLine(string line)
    {
        var matches = new Dictionary<char, char> { { '{', '}' }, { '(', ')' }, { '<', '>' }, { '[', ']' } };
        var closers = new StringBuilder();
        try
        {
            var stack = ParseLine(line);
            while (stack.Count > 0)
                closers.Append(matches[stack.Pop()]);
        }
        catch (Exception)
        {
            return "error";
        }

        return closers.ToString();
    }

    public List<char> GetCorruptedLines(List<string> syntaxData)
    {
        var corruptedChars = new List<char>();
        foreach (var line in syntaxData)
        {
            var character = CheckForCorruptedLine(line);
            corruptedChars.Add(character);
        }

        return corruptedChars;
    }

    private Stack<char> ParseLine(string line)
    {
        var matches = new Dictionary<char, char> { { '}', '{' }, { ')', '(' }, { '>', '<' }, { ']', '[' } };
        var stack = new Stack<char>();

        foreach (var c in line)
        {
            if (c == '{' || c == '[' || c == '<' || c == '(')
                stack.Push(c);
            else
            {
                var p = stack.Pop();
                if (matches[c] != p)
                    throw new Exception(c.ToString());
            }
        }

        return stack;
    }

    private char CheckForCorruptedLine(string line)
    {
        try
        {
            ParseLine(line);
            return '\0';
        }
        catch (Exception ex)
        {
            return ex.Message[0];
        }
    }
}
