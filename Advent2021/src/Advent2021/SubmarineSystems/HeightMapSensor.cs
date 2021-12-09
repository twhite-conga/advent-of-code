using Advent2021.Data.Models;

namespace Advent2021.SubmarineSystems;

public class HeightMapSensor
{
    private readonly ILogger<HeightMapSensor> _logger;

    public HeightMapSensor(ILogger<HeightMapSensor> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int SumLowPointRiskLevels(int[][] heightMap)
    {
        var lowPoints = GetLowPoints(heightMap);
        var answer = lowPoints.Sum(lp => lp + 1);
        _logger.LogCritical("What is the sum of the risk levels of all low points on your heightmap? Answer: {Answer}",
            answer);
        return answer;
    }

    private IEnumerable<int> GetLowPoints(int[][] heightMap)
    {
        var lowPointPositions = GetLowPointPositions(heightMap);
        return lowPointPositions.Select(coordinate => heightMap[coordinate.Y][coordinate.X]).ToList();
    }

    public int MultiplyThreeLargestBasins(int[][] heightMap)
    {
        var basins = MapBasins(heightMap);
        basins.Sort();
        basins.Reverse();
        var answer = basins[0] * basins[1] * basins[2];
        _logger.LogCritical(
            "What do you get if you multiply together the sizes of the three largest basins? Answer: {Answer}",
            answer);
        return answer;
    }

    private const int BasinEdgeHeight = 9;

    private List<int> MapBasins(int[][] heightMap)
    {
        var basinArea = new List<int>();
        var lowPoints = GetLowPointPositions(heightMap);
        foreach (var coordinate in lowPoints)
        {
            var basinCoordinates = new List<Coordinate> { coordinate };
            basinCoordinates = AddBasinCoordinates(heightMap, basinCoordinates);
            basinArea.Add(basinCoordinates.Count);
        }

        return basinArea;
    }

    private List<Coordinate> AddBasinCoordinates(int[][] heightMap, List<Coordinate> basinCoordinates)
    {
        var i = 0;
        while (i < basinCoordinates.Count)
        {
            var additionalCoordinates = new List<Coordinate>();
            for (var j = i; j < basinCoordinates.Count; j++)
            {
                foreach (var basinCoordinate in basinCoordinates)
                {
                    var coordinateBasinSides = GetCoordinateBasinSides(heightMap, basinCoordinate);
                    additionalCoordinates = additionalCoordinates.Concat(coordinateBasinSides).ToList();
                }
            }

            i = basinCoordinates.Count;
            foreach (var additionalCoordinate in additionalCoordinates)
            {
                if (!basinCoordinates.Exists(bc => bc.X == additionalCoordinate.X && bc.Y == additionalCoordinate.Y))
                {
                    basinCoordinates.Add(additionalCoordinate);
                }
            }
        }

        return basinCoordinates;
    }

    private List<Coordinate> GetCoordinateBasinSides(int[][] heightMap, Coordinate coordinate)
    {
        var coordinateBasinSides = new List<Coordinate>();
        // Left
        if (coordinate.X - 1 >= 0 && heightMap[coordinate.Y][coordinate.X - 1] < BasinEdgeHeight)
        {
            coordinateBasinSides.Add(new Coordinate { X = coordinate.X - 1, Y = coordinate.Y });
        }

        // Right
        if (coordinate.X + 1 < heightMap[coordinate.Y].Length &&
            heightMap[coordinate.Y][coordinate.X + 1] < BasinEdgeHeight)
        {
            coordinateBasinSides.Add(new Coordinate { X = coordinate.X + 1, Y = coordinate.Y });
        }

        // Up
        if (coordinate.Y - 1 >= 0 && heightMap[coordinate.Y - 1][coordinate.X] < BasinEdgeHeight)
        {
            coordinateBasinSides.Add(new Coordinate { X = coordinate.X, Y = coordinate.Y - 1 });
        }

        // Down
        if (coordinate.Y + 1 < heightMap.Length && heightMap[coordinate.Y + 1][coordinate.X] < BasinEdgeHeight)
        {
            coordinateBasinSides.Add(new Coordinate { X = coordinate.X, Y = coordinate.Y + 1 });
        }

        return coordinateBasinSides;
    }

    private IEnumerable<Coordinate> GetLowPointPositions(int[][] heightMap)
    {
        var lowPoints = new List<Coordinate>();
        for (var i = 0; i < heightMap.Length; i++)
        {
            var row = heightMap[i];
            for (var j = 0; j < row.Length; j++)
            {
                var point = row[j];
                int? left = j - 1 >= 0 && j - 1 < row.Length ? row[j - 1] : null;
                var isLowerThanLeft = left == null || point < left;
                int? right = j + 1 >= 0 && j + 1 < row.Length ? row[j + 1] : null;
                var isLowerThanRight = right == null || point < right;
                int? up = i - 1 >= 0 && i - 1 < heightMap.Length ? heightMap[i - 1][j] : null;
                var isLowerThanUp = up == null || point < up;
                int? down = i + 1 >= 0 && i + 1 < heightMap.Length ? heightMap[i + 1][j] : null;
                var isLowerThanDown = down == null || point < down;

                if (isLowerThanLeft && isLowerThanRight && isLowerThanUp && isLowerThanDown)
                {
                    lowPoints.Add(new Coordinate { X = j, Y = i });
                }
            }
        }

        return lowPoints;
    }
}
