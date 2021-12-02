using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Data
{
    public class DepthDataService : IDepthDataService
    {
        public List<int> ParseRawData(string data)
        {
            var dmStrings = data.Split(Environment.NewLine).ToList();
            var dms = new List<int>();
            foreach (var dmString in dmStrings)
            {
                int.TryParse(dmString, out var dm);
                dms.Add(dm);
            }

            return dms;
        }
    }
}
