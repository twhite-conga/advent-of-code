namespace Advent2021;

public class DiagnosticReport
{
    private readonly ILogger<DiagnosticReport> _logger;
    private const char One = '1';
    private const char Zero = '0';

    public DiagnosticReport(ILogger<DiagnosticReport> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetPowerConsumption(List<string> binaryInputs)
    {
        var (gammaRate, epsilonRate) = GetPowerRates(binaryInputs);
        var answer = gammaRate * epsilonRate;
        _logger.LogCritical("What is the power consumption of the submarine? Answer: {Answer}", answer);
        return answer;
    }

    private (int gammaRate, int epsilonRate) GetPowerRates(List<string> binaryInputs)
    {
        var digitMap = new List<string>();
        foreach (var binaryInput in binaryInputs)
        {
            for (var j = 0; j < binaryInput.Length; j++)
            {
                var digit = binaryInput[j];
                if (j > digitMap.Count - 1)
                {
                    digitMap.Add("");
                }

                digitMap[j] += digit;
            }
        }

        string gamma = null;
        string epsilon = null;
        foreach (var digitList in digitMap)
        {
            var count0 = digitList.Count(d => d == Zero);
            var count1 = digitList.Count(d => d == One);
            gamma += count0 > count1 ? One : Zero;
            epsilon += count0 > count1 ? Zero : One;
        }

        return (Convert.ToInt32(gamma, 2), Convert.ToInt32(epsilon, 2));
    }
}
