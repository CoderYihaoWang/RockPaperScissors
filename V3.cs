using RockPaperScissors;

namespace RockPaperScissorsV3;

public interface IElement
{
    Result Test(IElement opponent);
}

public class Rock : IElement
{
    public Result Test(IElement opponent)
        => opponent switch
        {
            Paper => Result.Lose,
            Scissors => Result.Win,
            _ => Result.Draw,
        };
}

public class Paper : IElement
{
    public Result Test(IElement opponent)
        => opponent switch
        {
            Rock => Result.Win,
            Scissors => Result.Lose,
            _ => Result.Draw,
        };
}

public class Scissors : IElement
{
    public Result Test(IElement opponent)
        => opponent switch
        {
            Paper => Result.Win,
            Rock => Result.Lose,
            _ => Result.Draw,
        };
}

public class Tests
{
    static readonly IElement Rock = new Rock();
    static readonly IElement Paper = new Paper();
    static readonly IElement Scissors = new Scissors();

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Test(IElement self, IElement opponent, Result result)
    {
        Assert.Equal(result, self.Test(opponent));
    }

    public static TheoryData<IElement, IElement, Result> TestCases => new()
    {
        { Rock, Rock, Result.Draw },
        { Rock, Paper, Result.Lose },
        { Rock, Scissors, Result.Win },
        { Paper, Rock, Result.Win },
        { Paper, Paper, Result.Draw },
        { Paper, Scissors, Result.Lose },
        { Scissors, Rock, Result.Lose },
        { Scissors, Paper, Result.Win },
        { Scissors, Scissors, Result.Draw },
    };
}