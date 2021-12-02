using Microsoft.Extensions.DependencyInjection;

var serviceProvider = ConfigureServices();

var depthDataService = serviceProvider.GetRequiredService<IDepthDataService>();
var depthMeasurements = depthDataService.ParseRawData(Data.RawData);

var sonarSweep = serviceProvider.GetRequiredService<SonarSweep>();
sonarSweep.GetDepthMeasurementIncreaseRate(depthMeasurements);
sonarSweep.GetSlidingWindowSums(depthMeasurements);

ServiceProvider ConfigureServices()
{
    return new ServiceCollection()
        .AddLogging(l => l.AddConsole())
        .AddSingleton<IDepthDataService, DepthDataService>()
        .AddSingleton<SonarSweep>()
        .BuildServiceProvider();
}
