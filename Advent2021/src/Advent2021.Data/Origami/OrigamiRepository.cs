using Advent2021.Data.Models;

namespace Advent2021.Data.Origami;

public class OrigamiRepository : IOrigamiRepository
{
    public OrigamiInstruction ParseInstructions(string data)
    {
        var lines = data.Split(Environment.NewLine).ToList();
        var splitIndex = lines.FindIndex(s => s == "");
        var rawCoordinates = lines.Take(splitIndex);
        var coordinates = rawCoordinates.ToList();
        var rawFolds = lines.Skip(splitIndex + 1).Take(coordinates.Count);
        var instructions = new OrigamiInstruction
        {
            Coordinates = coordinates.Select(rawCoordinate =>
            {
                var coordinateArr = rawCoordinate.Split(",");
                var coordinate = new Coordinate
                    { X = int.Parse(coordinateArr.First()), Y = int.Parse(coordinateArr.Last()) };
                return coordinate;
            }).ToList(),
            Folds = rawFolds.Select(rawFold =>
            {
                var foldArr = rawFold.Split(" ").Last().Split("=");
                var fold = new Fold { Direction = foldArr.First(), Distance = int.Parse(foldArr.Last()) };
                return fold;
            }).ToList()
        };
        return instructions;
    }
}
