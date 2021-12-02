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

            var depthDataService = serviceProvider.GetRequiredService<IDepthDataService>();
            var depthMeasurements = depthDataService.ParseRawData(Data.RawData);

            var sonarSweep = serviceProvider.GetRequiredService<SonarSweep>();
            sonarSweep.GetDepthMeasurementIncreaseRate(depthMeasurements);
            sonarSweep.GetSlidingWindowSums(depthMeasurements);
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogging(l => l.AddConsole())
                .AddSingleton<IDepthDataService, DepthDataService>()
                .AddSingleton<SonarSweep>()
                .BuildServiceProvider();
        }
    }
}
