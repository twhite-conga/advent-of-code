using System.Text.RegularExpressions;

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

    public List<char> GetCorruptedLines(List<string> syntaxData)
    {
        var corruptedChars = new List<char>();
        foreach (var line in syntaxData)
        {
            var character = ParseLine(line);
            corruptedChars.Add(character);
        }

        return corruptedChars;
    }

    private char ParseLine(string line)
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
                    return c;
            }
        }

        return '\0';
    }
}
