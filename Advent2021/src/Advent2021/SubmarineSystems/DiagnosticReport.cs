namespace Advent2021.SubmarineSystems;

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
        var digitMap = BuildDigitsMap(binaryInputs);

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

    private static List<string> BuildDigitsMap(List<string> binaryInputs)
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

        return digitMap;
    }

    public int GetLifeSupportRating(List<string> binaryInputs)
    {
        var oxygenGeneratorRating = GetLifeSupportByCriteria(binaryInputs,
            (count0, count1) => count1 >= count0);
        var co2ScrubberRating = GetLifeSupportByCriteria(binaryInputs,
            (count0, count1) => count1 < count0);
        var answer = oxygenGeneratorRating * co2ScrubberRating;
        _logger.LogCritical("What is the life support rating of the submarine? Answer: {Answer}", answer);
        return answer;
    }

    private int GetLifeSupportByCriteria(List<string> binaryInputs, Func<int, int, bool> criteria)
    {
        var arr = new string [binaryInputs.Count];
        binaryInputs.CopyTo(arr);
        var binaryList = arr.ToList();
        var i = 0;
        while (binaryList.Count > 1)
        {
            var digits = "";
            foreach (var binaryInput in binaryList)
            {
                digits += binaryInput[i];
            }
            var count0 = digits.Count(d => d == Zero);
            var count1 = digits.Count(d => d == One);
            binaryList = criteria(count0, count1) ?
                binaryList.Where(row => row[i] == One).ToList() :
                binaryList.Where(row => row[i] == Zero).ToList();

            i++;
        }

        return Convert.ToInt32(binaryList.First(), 2);
    }
}
