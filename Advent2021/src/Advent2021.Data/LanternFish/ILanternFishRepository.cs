namespace Advent2021.Data.LanternFish;

public interface ILanternFishRepository
{
    List<LanternFish> GetAll(string data);
}
