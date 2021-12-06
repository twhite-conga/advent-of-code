namespace Advent2021.Data.LanternFish;

public class LanternFishRepository : ILanternFishRepository
{
    public List<LanternFish> GetAll(string data)
    {
        var fishInts = data.Split(",");
        return fishInts.Select(fishInt => new LanternFish { GestationDaysLeft = int.Parse(fishInt) }).ToList();
    }
}
