namespace Advent2021.Data.Crabs;

public interface ICrabRepository
{
    List<Crab> ParseCrabs(string data);
}
