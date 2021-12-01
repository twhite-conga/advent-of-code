using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Advent2021.Tests
{
    public class SonarSweepTests
    {
        private readonly ILogger<SonarSweep> _logger;

        public static List<int> FakeDepthMeasurements = new List<int>
        {
            199, 200, 208, 210, 200,207, 240, 269, 260, 263
        };

        public SonarSweepTests()
        {
            _logger = Substitute.For<ILogger<SonarSweep>>();
        }

        [Fact]
        public void GetDepthMeasurementIncreaseRate_Counts_Increases()
        {
            var subject = new SonarSweep(_logger);

            var actual = subject.GetDepthMeasurementIncreaseRate(FakeDepthMeasurements);

            actual.Should().Be(7);
        }
    }
}
