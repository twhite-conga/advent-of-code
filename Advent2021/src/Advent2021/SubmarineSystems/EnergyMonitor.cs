using Advent2021.Data.Models;

namespace Advent2021.SubmarineSystems;

public class EnergyMonitor
{
    private readonly ILogger<EnergyMonitor> _logger;
    private const int FlashEnergyLevel = 9;
    private int _flashes = 0;

    public EnergyMonitor(ILogger<EnergyMonitor> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetTotalFlashes(int[][] grid, int count)
    {
        _flashes = 0;
        var i = 0;
        while (i < count)
        {
            i++;
            grid = Step(grid);
        }

        var answer = _flashes;
        _logger.LogCritical("How many total flashes are there after 100 steps? Answer: {Answer}", answer);
        return answer;
    }

    public int[][] Step(int[][] initialGrid)
    {
        // Increment
        var grid = Increment(initialGrid);

        // Flash
        var flashes = GetFlashCoordinates(grid);
        Flash(flashes, grid);

        // Reset
        Reset(grid);

        return grid;
    }

    private static int[][] Increment(int[][] initialGrid)
    {
        var grid = new int[10][];
        Array.Copy(initialGrid, grid, 10);
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                grid[i][j]++;
            }
        }

        return grid;
    }

    private static void Flash(List<Coordinate> flashes, int[][] grid)
    {
        var f = 0;
        while (f < flashes.Count)
        {
            var neighborFlashes = new List<Coordinate>();
            for (var j = f; j < flashes.Count; j++)
            {
                var flash = flashes[j];
                neighborFlashes = neighborFlashes.Concat(UpdateNeighbors(grid, flash.X, flash.Y)).ToList();
            }
            f = flashes.Count;
            foreach (var flash in neighborFlashes)
            {
                if (!flashes.Exists(bc => bc.X == flash.X && bc.Y == flash.Y))
                {
                    flashes.Add(flash);
                }
            }
        }
    }

    private void Reset(int[][] grid)
    {
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                var item = grid[i][j];
                if (item <= FlashEnergyLevel) continue;
                _flashes++;
                grid[i][j] = 0;
            }
        }
    }

    private static List<Coordinate> GetFlashCoordinates(int[][] grid)
    {
        var flashes = new List<Coordinate>();
        for (var i = 0; i < grid.Length; i++)
        {
            var row = grid[i];
            for (var j = 0; j < row.Length; j++)
            {
                var item = row[j];
                if (item > FlashEnergyLevel)
                {
                    flashes.Add(new Coordinate { X = j, Y = i });
                }
            }
        }

        return flashes;
    }

    private static List<Coordinate> UpdateNeighbors(int[][] grid, int x, int y)
    {
        var neighbors = new List<Coordinate>();
        if (x - 1 >= 0) neighbors.Add(new Coordinate { X = x - 1, Y = y }); // left
        if (x + 1 < grid[y].Length) neighbors.Add(new Coordinate { X = x + 1, Y = y }); // right
        if (y - 1 >= 0) neighbors.Add(new Coordinate { X = x, Y = y - 1 }); // up
        if (y + 1 < grid.Length) neighbors.Add(new Coordinate { X = x, Y = y + 1 }); // down
        if (x - 1 >= 0 && y - 1 >= 0) neighbors.Add(new Coordinate { X = x - 1, Y = y - 1 }); // left up
        if (x + 1 < grid[y].Length && y - 1 >= 0) neighbors.Add(new Coordinate { X = x + 1, Y = y - 1 }); // right up
        if (x - 1 >= 0 && y + 1 < grid.Length) neighbors.Add(new Coordinate { X = x - 1, Y = y + 1 }); // left down
        if (x + 1 < grid[y].Length && y + 1 < grid.Length)
            neighbors.Add(new Coordinate { X = x + 1, Y = y + 1 }); // right down

        var flashes = new List<Coordinate>();
        foreach (var coordinate in neighbors)
        {
            grid[coordinate.Y][coordinate.X]++;
            var item = grid[coordinate.Y][coordinate.X];
            if (item > FlashEnergyLevel)
            {
                flashes.Add(coordinate);
            }
        }

        return flashes;
    }
}
