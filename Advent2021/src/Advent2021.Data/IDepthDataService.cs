using System.Collections.Generic;

namespace Advent2021
{
    public interface IDepthDataService
    {
        List<int> ParseRawData(string data);
    }
}
