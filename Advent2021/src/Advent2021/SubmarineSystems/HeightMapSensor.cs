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
        var lowPoints = new List<int>();
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
                    lowPoints.Add(point);
                }
            }
        }
        return lowPoints;
    }
}
