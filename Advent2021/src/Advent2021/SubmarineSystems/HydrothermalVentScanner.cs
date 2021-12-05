using Advent2021.Data.Models;

namespace Advent2021.SubmarineSystems;

public class HydrothermalVentScanner
{
    private readonly ILogger<HydrothermalVentScanner> _logger;

    public HydrothermalVentScanner(ILogger<HydrothermalVentScanner> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int ScanForDangerousOverlaps(List<CoordinateLine> coordinateLines)
    {
        var coordinateOverlapMap = GetOverlappingCoordinates(coordinateLines);
        var answer = coordinateOverlapMap.Count(c => c.Value > 1);
        _logger.LogCritical("At how many points do at least two lines overlap? Answer: {Answer}", answer);
        return answer;
    }

    public int ScanForDangerousOverlapsWithDiagonal(List<CoordinateLine> coordinateLines)
    {
        var coordinateOverlapMap = GetOverlappingCoordinates(coordinateLines, true);
        var answer = coordinateOverlapMap.Count(c => c.Value > 1);
        _logger.LogCritical("At how many points do at least two lines overlap (with diagonal)? Answer: {Answer}",
            answer);
        return answer;
    }

    private static Dictionary<Coordinate, int> GetOverlappingCoordinates(List<CoordinateLine> coordinateLines,
        bool inclueDiagonal = false)
    {
        var coordinateOverlapMap = new Dictionary<Coordinate, int>();
        foreach (var coordinateLine in coordinateLines)
        {
            var lineCoordinates = GetLineCoordinates(coordinateLine, inclueDiagonal);
            foreach (var coordinate in lineCoordinates)
            {
                var key = coordinateOverlapMap.Keys.FirstOrDefault(c => c.X == coordinate.X && c.Y == coordinate.Y);
                if (key != null)
                {
                    coordinateOverlapMap[key]++;
                }
                else
                {
                    coordinateOverlapMap.Add(coordinate, 1);
                }
            }
        }

        return coordinateOverlapMap;
    }

    private static List<Coordinate> GetLineCoordinates(CoordinateLine coordinateLine, bool inclueDiagonal = false)
    {
        var coordinates = new List<Coordinate>();
        if (coordinateLine.Start.X == coordinateLine.End.X)
        {
            var start = Math.Min(coordinateLine.Start.Y, coordinateLine.End.Y);
            var end = Math.Max(coordinateLine.Start.Y, coordinateLine.End.Y);
            for (var i = start; i <= end; i++)
            {
                coordinates.Add(new Coordinate { X = coordinateLine.Start.X, Y = i });
            }
        }
        else if (coordinateLine.Start.Y == coordinateLine.End.Y)
        {
            var start = Math.Min(coordinateLine.Start.X, coordinateLine.End.X);
            var end = Math.Max(coordinateLine.Start.X, coordinateLine.End.X);
            for (var i = start; i <= end; i++)
            {
                coordinates.Add(new Coordinate { X = i, Y = coordinateLine.Start.Y });
            }
        }
        else if (inclueDiagonal)
        {
            var startX = Math.Min(coordinateLine.Start.X, coordinateLine.End.X);
            var endX = Math.Max(coordinateLine.Start.X, coordinateLine.End.X);
            var length = endX - startX;
            var yDirection = coordinateLine.Start.Y < coordinateLine.End.Y ? 1 : -1;
            var xDirection = coordinateLine.Start.X < coordinateLine.End.X ? 1 : -1;
            for (var i = 0; i <= length; i++)
            {
                coordinates.Add(new Coordinate
                    { X = coordinateLine.Start.X + xDirection * i, Y = coordinateLine.Start.Y + yDirection * i });
            }
        }

        return coordinates;
    }
}
