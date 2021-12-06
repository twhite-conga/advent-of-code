using Advent2021.Data.LanternFish;

namespace Advent2021.Data.Tests.LanternFish;

public class LanternFishRepositoryTests
{
    public const string FakeLanternFishData = "3,4,3,1,2";

    [Fact]
    public void GetAll_Returns_Fishes()
    {
        var subject = new LanternFishRepository();

        var actual = subject.GetAll(FakeLanternFishData);

        actual.First().GestationDaysLeft.Should().Be(3);
        actual.Last().GestationDaysLeft.Should().Be(2);
    }
}
