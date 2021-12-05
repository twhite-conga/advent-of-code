namespace Advent2021.SubmarineSystems;

public class HydrothermalVentScanner
{
    private readonly ILogger<HydrothermalVentScanner> _logger;

    public HydrothermalVentScanner(ILogger<HydrothermalVentScanner> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int ScanForDangerousOverlaps()
    {
        var answer = 0;
        _logger.LogCritical("At how many points do at least two lines overlap? Answer: {Answer}", answer);
        return answer;
    }
}
