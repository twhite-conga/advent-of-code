using Advent2021.Data.Models;

namespace Advent2021.Data.Origami;

public class OrigamiInstruction
{
    public List<Coordinate> Coordinates { get; init; }
    public List<Fold> Folds { get; init; }
}
