using Advent2021.Data.Crabs;
using Advent2021.Data.HeighMap;
using Advent2021.SubmarineSystems;
using Microsoft.Extensions.DependencyInjection;
using Advent2021.Data.LanternFish;
using Advent2021.Data.OctopusEnergy;
using Advent2021.Data.SensorFix;
using Data = Advent2021.Data.Data;

var serviceProvider = ConfigureServices();

var rawDataService = serviceProvider.GetRequiredService<IRawDataService>();

Day1();
Day2();
Day3();
Day4();
// Day5();
Day6();
Day7();
Day8();
Day9();

Day11();

ServiceProvider ConfigureServices()
{
    return new ServiceCollection()
        .AddLogging(l => l.AddConsole())
        .AddTransient<IRawDataService, RawDataService>()
        .AddTransient<SonarSweep>()
        .AddTransient<Navigation>()
        .AddTransient<DiagnosticReport>()
        .AddTransient<BingoSubsystem>()
        .AddTransient<HydrothermalVentScanner>()
        .AddTransient<ILanternFishRepository, LanternFishRepository>()
        .AddTransient<LanternFishCalculator>()
        .AddTransient<ICrabRepository, CrabRepository>()
        .AddTransient<CrabAlignmentSystem>()
        .AddTransient<ISensorFixRepository, SensorFixRepository>()
        .AddTransient<SensorFix>()
        .AddTransient<IHeightMapRepository, HeightMapRepository>()
        .AddTransient<HeightMapSensor>()
        .AddTransient<IOctopusEnergyRepository, OctopusEnergyRepository>()
        .AddTransient<EnergyMonitor>()
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

void Day4()
{
    var bingoSubsystem = serviceProvider.GetRequiredService<BingoSubsystem>();
    bingoSubsystem.CalculateFirstWinningBoardScore(rawDataService.ParseRawBingoData(Data.RawBingoInput));
    bingoSubsystem.CalculateLastWinningBoardScore(rawDataService.ParseRawBingoData(Data.RawBingoInput));
}

void Day5()
{
    var hydrothermalVentScanner = serviceProvider.GetRequiredService<HydrothermalVentScanner>();
    var data = rawDataService.ParseRawHydrothermicData(Data.RawVentData);
    hydrothermalVentScanner.ScanForDangerousOverlaps(data);
    hydrothermalVentScanner.ScanForDangerousOverlapsWithDiagonal(data);
}

void Day6()
{
    var lanternFishCalculator = serviceProvider.GetRequiredService<LanternFishCalculator>();
    var repository = serviceProvider.GetRequiredService<ILanternFishRepository>();
    var data = repository.GetAll(Advent2021.Data.LanternFish.Data.RawLanternFishStateData);
    lanternFishCalculator.CalculatePopulation(80, data);
    lanternFishCalculator.CalculatePopulation(256, data);
}

void Day7()
{
    var repository = serviceProvider.GetRequiredService<ICrabRepository>();
    var data = repository.ParsePositions(Advent2021.Data.Crabs.Data.RawCrabPostions);
    var alignmentSystem = serviceProvider.GetRequiredService<CrabAlignmentSystem>();
    alignmentSystem.GetCheapestAlignmentFuelCost(data);
    alignmentSystem.GetCheapestAlignmentIncreasingFuelCost(data);
}

void Day8()
{
    var repository = serviceProvider.GetRequiredService<ISensorFixRepository>();
    var data = repository.ParseReadings(Advent2021.Data.SensorFix.Data.RawSensorData);
    var sensorFix = serviceProvider.GetRequiredService<SensorFix>();
    sensorFix.CheckForKnowDigits(data);
    sensorFix.AddAllOutputValues(data);
}

void Day9()
{
    var repository = serviceProvider.GetRequiredService<IHeightMapRepository>();
    var data = repository.ParseHeightMap(Advent2021.Data.HeighMap.Data.RawHeighMapData);
    var heightMapSensor = serviceProvider.GetRequiredService<HeightMapSensor>();
    heightMapSensor.SumLowPointRiskLevels(data);
    heightMapSensor.MultiplyThreeLargestBasins(data);
}

void Day11()
{
    var repository = serviceProvider.GetRequiredService<IOctopusEnergyRepository>();
    var data = repository.ParseGrid(Advent2021.Data.OctopusEnergy.Data.RawOctopusEnergyData);
    var energyMonitor = serviceProvider.GetRequiredService<EnergyMonitor>();
}
