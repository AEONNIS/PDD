public class PlayerStatsResults
{
    private PlayerStatsAmounts _amounts;
    private PlayerStatsAverageTimes _averageTimes;

    public PlayerStatsAmounts Amounts => _amounts;
    public PlayerStatsAverageTimes AverageTimes => _averageTimes;

    public PlayerStatsResults(PlayerStatsAmounts amounts, PlayerStatsAverageTimes averageTimes)
    {
        _amounts = amounts;
        _averageTimes = averageTimes;
    }
}
