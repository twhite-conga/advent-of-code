using Advent2021.Data.Models;
using Advent2021.Models;

namespace Advent2021;

public class Navigation
{
    public const string Forward = "forward";
    public const string Up = "up";
    public const string Down = "down";

    private readonly ILogger<Navigation> _logger;

    public Navigation(ILogger<Navigation> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int MultiplyHorizontalDepthPositions(List<NavPoint> navPoints)
    {
        var finalPosition = GetFinalPosition(navPoints);
        var answer = finalPosition.Horizontal * finalPosition.Depth;
        _logger.LogCritical("What do you get if you multiply your final horizontal position by your final depth? Answer: {Answer}", answer);
        return answer;
    }

    private Position GetFinalPosition(List<NavPoint> navPoints)
    {
        var finalPosition = new Position { Depth = 0, Horizontal = 0 };
        foreach (var navPoint in navPoints)
        {
            switch (navPoint.Direction)
            {
                case Up:
                    finalPosition.Depth -= navPoint.Distance;
                    break;
                case Down:
                    finalPosition.Depth += navPoint.Distance;
                    break;
                case Forward:
                    finalPosition.Horizontal += navPoint.Distance;
                    break;
            }
        }
        return finalPosition;
    }
}
