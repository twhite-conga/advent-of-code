namespace Advent2021.Data.HeighMap;

public class HeightMapRepository : IHeightMapRepository
{
    public int[][] ParseHeightMap(string data)
    {
        var rows = data.Split(Environment.NewLine);
        var heightMap = new int[rows.Length][];
        for (var i = 0; i < rows.Length; i++)
        {
            var row = rows[i];
            heightMap[i] = new int[row.Length];
            for (var j = 0; j < row.Length; j++)
            {
                heightMap[i][j] = int.Parse(row[j].ToString());
            }
        }

        return heightMap;
    }
}
