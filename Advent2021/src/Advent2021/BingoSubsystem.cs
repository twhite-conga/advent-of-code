using Advent2021.Data.Models;

namespace Advent2021;

public class BingoSubsystem
{
    private readonly ILogger<BingoSubsystem> _logger;

    public BingoSubsystem(ILogger<BingoSubsystem> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int CalculateFirstWinningBoardScore(BingoDataSet bingoDataSet)
    {
        var (key, value) = FindWinningBoards(bingoDataSet).First();
        var winningBoardSum = CalculateWinningBoardSum(value);

        var answer = winningBoardSum * key;
        _logger.LogCritical("What will your final score be if you choose that board? Answer: {Answer}", answer);
        return answer;
    }

    public int CalculateLastWinningBoardScore(BingoDataSet bingoDataSet)
    {
        var (key, value) = FindWinningBoards(bingoDataSet).Last();
        var winningBoardSum = CalculateWinningBoardSum(value);

        var answer = winningBoardSum * key;
        _logger.LogCritical("Once it wins, what would its final score be (last winning board)? Answer: {Answer}",
            answer);
        return answer;
    }

    private static int CalculateWinningBoardSum(BingoBoard winningBoard)
    {
        var winningBoardSum = 0;
        foreach (var winningBoardSquare in winningBoard.Rows)
        {
            winningBoardSum += winningBoardSquare
                .Where(bingoSquare => !bingoSquare.IsHit)
                .Sum(bingoSquare => bingoSquare.Value);
        }

        return winningBoardSum;
    }

    private List<KeyValuePair<int, BingoBoard>> FindWinningBoards(BingoDataSet bingoDataSet)
    {
        var winningBoardMap = new List<KeyValuePair<int, BingoBoard>>();
        foreach (var drawing in bingoDataSet.Drawings)
        {
            foreach (var bingoBoard in bingoDataSet.Boards)
            {
                if (bingoBoard.HasWon) continue;
                foreach (var row in bingoBoard.Rows)
                {
                    foreach (var bingoSquare in row)
                    {
                        if (bingoSquare.Value.Equals(drawing))
                        {
                            bingoSquare.IsHit = true;
                        }
                    }
                }

                if (!HasBoardWon(bingoBoard)) continue;
                bingoBoard.HasWon = true;
                winningBoardMap.Add(new KeyValuePair<int, BingoBoard>(drawing, bingoBoard));
            }
        }

        return winningBoardMap;
    }

    private bool HasBoardWon(BingoBoard bingoBoard)
    {
        return bingoBoard.Rows.Any(squares => squares.All(square => square.IsHit)) ||
               bingoBoard.Columns.Any(squares => squares.All(square => square.IsHit));
    }
}
