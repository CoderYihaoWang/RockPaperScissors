using RockPaperScissors;

namespace RockPaperScissorsV2;

public class RockPaperScissors
{
    public static Result Test(IElement self, IElement opponent)
        => (self, opponent) switch
        {
            (Rock, Scissors) => Result.Win,
            (Scissors, Paper) => Result.Win,
            (Paper, Rock) => Result.Win,
            (Scissors, Rock) => Result.Lose,
            (Paper, Scissors) => Result.Lose,
            (Rock, Paper) => Result.Lose,
            (_, _) => Result.Draw,
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
        Assert.Equal(result, RockPaperScissors.Test(self, opponent));
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