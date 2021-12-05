using Advent2021.Data.Models;

namespace Advent2021.Data;

public interface IRawDataService
{
    List<string> ParseRawData(string data);
    List<int> ParseRawDepthData(string data);
    List<NavPoint> ParseRawNavigationData(string data);
    BingoDataSet ParseRawBingoData(string data);
    List<CoordinateLine> ParseRawHydrothermicData(string data);
}
