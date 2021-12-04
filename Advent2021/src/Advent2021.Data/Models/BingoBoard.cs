namespace Advent2021.Data.Models;

public class BingoBoard
{
    public List<List<BingoSquare>> Rows { get; } = new();

    public List<List<BingoSquare>> Columns
    {
        get
        {
            var columns = new List<List<BingoSquare>>();
            for (var i = 0; i < Rows.Count; i++)
            {
                for (var j = 0; j < Rows[i].Count; j++)
                {
                    List<BingoSquare> column;
                    if (i == 0)
                    {
                        column = new List<BingoSquare>();
                        columns.Add(column);
                    }
                    else
                    {
                        column = columns[j];
                    }
                    column.Add(Rows[i][j]);
                }
            }

            return columns;
        }
    }

    public bool HasWon { get; set; }
}
