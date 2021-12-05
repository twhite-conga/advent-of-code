using Advent2021.Data;
using Advent2021.Data.Models;
using Advent2021.Data.Tests;
using Advent2021.SubmarineSystems;

namespace Advent2021.Tests.SubmarineSystems;

public class HydrothermalVentScannerTests
{
    private readonly ILogger<HydrothermalVentScanner> _logger;

    private readonly List<CoordinateLine> _fakeCoordinateLines;

    public HydrothermalVentScannerTests()
    {
        _logger = Substitute.For<ILogger<HydrothermalVentScanner>>();
        var parser = new RawDataService();
        _fakeCoordinateLines = parser.ParseRawHydrothermicData(RawDataServiceTests.FakeHydrothermicVentsData);
    }

    [Fact]
    public void ScanForDangerousOverlaps_Scans_For_Overlaps()
    {
        var subject = new HydrothermalVentScanner(_logger);

        var actual = subject.ScanForDangerousOverlaps(_fakeCoordinateLines);

        actual.Should().Be(5);
    }

    [Fact]
    public void ScanForDangerousOverlapsWithDiagonal_Scans_For_Overlaps()
    {
        var subject = new HydrothermalVentScanner(_logger);

        var actual = subject.ScanForDangerousOverlapsWithDiagonal(_fakeCoordinateLines);

        actual.Should().Be(12);
    }
}
