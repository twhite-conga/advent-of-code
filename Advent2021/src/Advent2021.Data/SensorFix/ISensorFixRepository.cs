namespace Advent2021.Data.SensorFix;

public interface ISensorFixRepository
{
    List<SensorReading> ParseReadings(string data);
}
