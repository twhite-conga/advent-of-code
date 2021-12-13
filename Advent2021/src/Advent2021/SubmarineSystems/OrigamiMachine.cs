using Advent2021.Data.Models;
using Advent2021.Data.Origami;

namespace Advent2021.SubmarineSystems;

public class OrigamiMachine
{
    private readonly ILogger<OrigamiMachine> _logger;

    public OrigamiMachine(ILogger<OrigamiMachine> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetVisibleDotsAfterFirstFold(OrigamiInstruction instruction)
    {
        var foldedCoordinates = Fold(instruction.Folds.First(), instruction.Coordinates);
        var answer = foldedCoordinates.Count;
        _logger.LogCritical(
            "How many dots are visible after completing just the first fold instruction on your transparent paper? Answer: {Answer}",
            answer);
        return answer;
    }

    public int GetCodeAfterAllFolds(OrigamiInstruction instruction)
    {
        var foldedCoordinates = instruction.Coordinates;
        foreach (var fold in instruction.Folds)
        {
            foldedCoordinates = Fold(fold, foldedCoordinates);
        }

        var answer = foldedCoordinates.Count;
        _logger.LogCritical(
            "What code do you use to activate the infrared thermal imaging camera system? Answer: {Answer}",
            answer);
        var minX = foldedCoordinates.Min(c => c.X);
        var maxX = foldedCoordinates.Max(c => c.X) + 1;
        var minY = foldedCoordinates.Min(c => c.Y);
        var maxY = foldedCoordinates.Max(c => c.Y) + 1;
        for (var i = minY; i < maxY; i++)
        {
            var line = "";
            for (var j = minX; j < maxX; j++)
            {
                var mark = " ";
                if (foldedCoordinates.Exists(c => c.X == j && c.Y == i))
                {
                    mark = "#";
                }

                line += mark;
            }

            Console.WriteLine(line);
        }

        return answer;
    }

    private List<Coordinate> Fold(Fold fold, List<Coordinate> coordinates)
    {
        var foldedCoordinates = new List<Coordinate>();
        foreach (var coordinate in coordinates)
        {
            if (fold.Direction == Data.Origami.Fold.X)
            {
                if (coordinate.X > fold.Axis)
                {
                    var foldCoordinate = new Coordinate
                        { X = fold.Axis - (coordinate.X - fold.Axis), Y = coordinate.Y };
                    if (!foldedCoordinates.Exists(c => c.X == foldCoordinate.X && c.Y == foldCoordinate.Y))
                    {
                        foldedCoordinates.Add(foldCoordinate);
                    }
                }
                else
                {
                    if (!foldedCoordinates.Exists(c => c.X == coordinate.X && c.Y == coordinate.Y))
                    {
                        foldedCoordinates.Add(coordinate);
                    }
                }
            }
            else if (fold.Direction == Data.Origami.Fold.Y)
            {
                if (coordinate.Y > fold.Axis)
                {
                    var foldCoordinate = new Coordinate
                        { X = coordinate.X, Y = fold.Axis - (coordinate.Y - fold.Axis) };
                    if (!foldedCoordinates.Exists(c => c.X == foldCoordinate.X && c.Y == foldCoordinate.Y))
                    {
                        foldedCoordinates.Add(foldCoordinate);
                    }
                }
                else
                {
                    if (!foldedCoordinates.Exists(c => c.X == coordinate.X && c.Y == coordinate.Y))
                    {
                        foldedCoordinates.Add(coordinate);
                    }
                }
            }
        }

        return foldedCoordinates;
    }
}
