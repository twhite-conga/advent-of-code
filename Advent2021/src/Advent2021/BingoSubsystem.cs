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
        foreach (var winningBoardRow in winningBoard.Rows)
        {
            winningBoardSum += winningBoardRow
                .Where(bingoSquare => !bingoSquare.IsHit)
                .Sum(bingoSquare => bingoSquare.Value);
        }
        var answer = winningBoardSum * winningNumber;
        _logger.LogCritical("What will your final score be if you choose that board? Answer: {Answer}", answer);
        return answer;
    }

    private (BingoBoard winningBoard, int winningNumber) FindWinningBoard(BingoDataSet bingoDataSet)
    {
        throw new NotImplementedException();
    }

    private
}
