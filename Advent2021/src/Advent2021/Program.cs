using System.Diagnostics.CodeAnalysis;
using Advent2021.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Advent2021
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var depthDataService = serviceProvider.GetRequiredService<IDepthDataService>();
            var depthMeasurements = depthDataService.ParseRawData(Data.Data.RawData);

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
