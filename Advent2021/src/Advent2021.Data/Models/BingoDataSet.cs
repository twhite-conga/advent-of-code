namespace Advent2021.Data.Models;

public class BingoDataSet
{
    public List<int> Drawings { get; } = new();
    public List<BingoBoard> Boards { get; } = new();
}
