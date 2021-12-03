using Microsoft.Extensions.DependencyInjection;

var serviceProvider = ConfigureServices();

var rawDataService = serviceProvider.GetRequiredService<IRawDataService>();

Day1();
Day2();
Day3();

ServiceProvider ConfigureServices()
{
    return new ServiceCollection()
        .AddLogging(l => l.AddConsole())
        .AddSingleton<IRawDataService, RawDataService>()
        .AddSingleton<SonarSweep>()
        .AddSingleton<Navigation>()
        .AddSingleton<DiagnosticReport>()
        .BuildServiceProvider();
}

void Day1()
{
    var depthMeasurements = rawDataService.ParseRawDepthData(Data.RawDepthMeasurementData);
    var sonarSweep = serviceProvider.GetRequiredService<SonarSweep>();
    sonarSweep.GetDepthMeasurementIncreaseRate(depthMeasurements);
    sonarSweep.GetSlidingWindowSums(depthMeasurements);
}

void Day2()
{
    var navPoints = rawDataService.ParseRawNavigationData(Data.RawPlottedCourseData);
    var navigation = serviceProvider.GetRequiredService<Navigation>();
    navigation.MultiplyHorizontalDepthPositions(navPoints);
    navigation.MultiplyHorizontalDepthPositionsWithAim(navPoints);
}

void Day3()
{
    var binaryPowerData = rawDataService.ParseRawData(Data.RawBinaryPowerData);
    var diagnosticReport = serviceProvider.GetRequiredService<DiagnosticReport>();
    diagnosticReport.GetPowerConsumption(binaryPowerData);
    diagnosticReport.GetLifeSupportRating(binaryPowerData);
}
