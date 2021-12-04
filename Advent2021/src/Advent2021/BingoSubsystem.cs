using Advent2021.Data.Models;

namespace Advent2021;

public class BingoSubsystem
{
    private readonly ILogger<BingoSubsystem> _logger;

    public BingoSubsystem(ILogger<BingoSubsystem> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int CalculateWinnerScore(BingoDataSet bingoDataSet)
    {
        var (winningBoard, winningNumber) = FindWinningBoard(bingoDataSet);
        var winningBoardSum = 0;
        foreach (var winningBoardSquare in winningBoard.Rows)
        {
            winningBoardSum += winningBoardSquare
                .Where(bingoSquare => !bingoSquare.IsHit)
                .Sum(bingoSquare => bingoSquare.Value);
        }

        var answer = winningBoardSum * winningNumber;
        _logger.LogCritical("What will your final score be if you choose that board? Answer: {Answer}", answer);
        return answer;
    }

    private (BingoBoard winningBoard, int winningNumber) FindWinningBoard(BingoDataSet bingoDataSet)
    {
        foreach (var drawing in bingoDataSet.Drawings)
        {
            foreach (var bingoBoard in bingoDataSet.Boards)
            {
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

                if (HasBoardWon(bingoBoard))
                {
                    return (bingoBoard, drawing);
                }
            }
        }

        throw new Exception("No board won from drawing set");
    }

    private bool HasBoardWon(BingoBoard bingoBoard)
    {
        return bingoBoard.Rows.Any(squares => squares.All(square => square.IsHit)) ||
               bingoBoard.Columns.Any(squares => squares.All(square => square.IsHit));
    }
}
