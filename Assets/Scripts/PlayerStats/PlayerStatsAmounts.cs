public class PlayerStatsAmounts
{
    private int _totalGames;
    private int _wins;
    private int _losses;
    private int _timeIsOverLosses;
    private int _wrongAnswerLosses;

    public int TotalGames => _totalGames;
    public int Wins => _wins;
    public int Losses => _losses;
    public int TimeIsOverLosses => _timeIsOverLosses;
    public int WrongAnswerLosses => _wrongAnswerLosses;

    public PlayerStatsAmounts(int totalGames, int wins, int losses, int timeIsOverLosses, int wrongAnswerLosses)
    {
        _totalGames = totalGames;
        _wins = wins;
        _losses = losses;
        _timeIsOverLosses = timeIsOverLosses;
        _wrongAnswerLosses = wrongAnswerLosses;
    }
}
