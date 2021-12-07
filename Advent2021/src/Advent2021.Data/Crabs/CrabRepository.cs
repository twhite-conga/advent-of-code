namespace Advent2021.Data.Crabs;

public class CrabRepository : ICrabRepository
{
    public List<Crab> ParseCrabs(string data)
    {
        return data.Split(",")
            .Select(position => new Crab { HorizontalPosition = int.Parse(position) })
            .ToList();
    }
}
