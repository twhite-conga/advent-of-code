namespace Advent2021.Data.Crabs;

public class CrabRepository : ICrabRepository
{
    public List<int> ParsePositions(string data)
    {
        return data.Split(",")
            .Select(int.Parse)
            .ToList();
    }
}
