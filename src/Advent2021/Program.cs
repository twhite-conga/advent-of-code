using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Advent2021
{
    internal static class Program
    {
        private static List<string> _depthMeasurements;

        private static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var sonarSweep = serviceProvider.GetRequiredService<SonarSweep>();
            sonarSweep.GetDepthMeasurementIncreaseRate(Data.DepthMeasurements);
            sonarSweep.GetSlidingWindowSums(Data.DepthMeasurements);
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogging(l => l.AddConsole())
                .AddSingleton<SonarSweep>()
                .BuildServiceProvider();
        }
    }
}
