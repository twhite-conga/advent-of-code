namespace Advent2021.Data.OctopusEnergy;

public class OctopusEnergyRepository : IOctopusEnergyRepository
{
    public int[][] ParseGrid(string data)
    {
        var rowStrings = data.Split(Environment.NewLine);
        var grid = new int[10][];
        for (var i = 0; i < rowStrings.Length; i++)
        {
            var row = new int[10];
            for (int j = 0; j < rowStrings[i].Length; j++)
            {
                row[j] = int.Parse(rowStrings[i][j].ToString());
            }

            grid[i] = row;
        }

        return grid;
    }
}
