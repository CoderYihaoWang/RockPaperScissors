namespace RockPaperScissors;

public enum Result { Win, Lose, Draw }

public interface IElement
{
    Result Test(IElement opponent);
    Result TestedByRock();
    Result TestedByPaper();
    Result TestedByScissors();
}

public class Rock : IElement
{
    public Result Test(IElement opponent) => opponent.TestedByRock();

    public Result TestedByRock() => Result.Draw;
    public Result TestedByPaper() => Result.Win;
    public Result TestedByScissors() => Result.Lose;
}

public class Paper : IElement
{
    public Result Test(IElement opponent) => opponent.TestedByPaper();

    public Result TestedByRock() => Result.Lose;
    public Result TestedByPaper() => Result.Draw;
    public Result TestedByScissors() => Result.Win;
}

public class Scissors : IElement
{
    public Result Test(IElement opponent) => opponent.TestedByScissors();

    public Result TestedByRock() => Result.Win;
    public Result TestedByPaper() => Result.Lose;
    public Result TestedByScissors() => Result.Draw;
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