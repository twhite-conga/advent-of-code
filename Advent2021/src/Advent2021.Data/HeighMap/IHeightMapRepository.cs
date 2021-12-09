namespace Advent2021.Data.HeighMap;

public interface IHeightMapRepository
{
    int[][] ParseHeightMap(string data);
}
