using Advent2021.Data.Models;

namespace Advent2021.Data;

public class RawDataService : IRawDataService
{
    public List<string> ParseRawData(string data)
    {
        return data.Split(Environment.NewLine).ToList();
    }

    public List<int> ParseRawDepthData(string data)
    {
        var dmStrings = ParseRawData(data);
        var dms = new List<int>();
        foreach (var dmString in dmStrings)
        {
            int.TryParse(dmString, out var dm);
            dms.Add(dm);
        }

        return dms;
    }

    public List<NavPoint> ParseRawNavigationData(string data)
    {
        var navStrings = ParseRawData(data);
        var navPoints = new List<NavPoint>();
        foreach (var navString in navStrings)
        {
            var navParts = navString.Split(" ");
            var navPoint = new NavPoint
            {
                Direction = navParts.First(),
                Distance = int.Parse(navParts.Last())
            };
            navPoints.Add(navPoint);
        }

        return navPoints;
    }
}
