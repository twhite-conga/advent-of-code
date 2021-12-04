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
        int answer = 0;
        _logger.LogCritical("What will your final score be if you choose that board? Answer: {Answer}", answer);
        return answer;
    }
}
