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

    public BingoDataSet ParseRawBingoData(string data)
    {
        var bingoStrings = ParseRawData(data);
        var bingoDataSet = new BingoDataSet();
        var drawings = bingoStrings.First().Split(",");
        foreach (var drawing in drawings)
        {
            bingoDataSet.Drawings.Add(int.Parse(drawing));
        }
        bingoStrings.RemoveRange(0, 2);

        while (bingoStrings.Count > 0)
        {
            var removeCount = 0;
            var board = new BingoBoard();
            bingoDataSet.Boards.Add(board);
            foreach (var line in bingoStrings)
            {
                removeCount++;
                if (line == "")
                {
                    break;
                }

                var row = new List<BingoSquare>();
                var rowSquares = line.Split(" ").ToList().Where(rs => rs != "");
                foreach (var rowSquareValue in rowSquares)
                {
                    row.Add(new BingoSquare{Value = int.Parse(rowSquareValue)});
                }
                board.Rows.Add(row);
            }
            bingoStrings.RemoveRange(0, removeCount);
        }

        return bingoDataSet;
    }
}
