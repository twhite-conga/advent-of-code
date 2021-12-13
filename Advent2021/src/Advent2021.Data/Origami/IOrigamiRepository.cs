namespace Advent2021.Data.Origami;

public interface IOrigamiRepository
{
    OrigamiInstruction ParseInstructions(string data);
}
