using Advent2021.Data.Models;

namespace Advent2021.Data;

public interface IRawDataService
{
    List<int> ParseRawDepthData(string data);

    List<NavPoint> ParseRawNavigationData(string data);
}
