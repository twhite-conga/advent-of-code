using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Advent2021
{
    public class SonarSweep
    {
        private readonly ILogger<SonarSweep> _logger;

        public SonarSweep(ILogger<SonarSweep> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int GetDepthMeasurementIncreaseRate(List<int> depthMeasurements)
        {
            var increases = 0;
            for (var i = 1; i < depthMeasurements.Count; i++)
            {
                var depthMeasurement = depthMeasurements[i];
                var previousDepthMeasurement = depthMeasurements[i - 1];
                if (depthMeasurement > previousDepthMeasurement) increases++;
                _logger.LogError("Depth Measurement: {DepthMeasurement}", depthMeasurement);
            }

            _logger.LogCritical("How many measurements are larger than the previous measurement? Answer: {Increases}",
                increases);
            return increases;
        }
    }
}
