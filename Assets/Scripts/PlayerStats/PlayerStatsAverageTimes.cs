public class PlayerStatsAverageTimes
{
    private float _game;
    private float _signsPlacement;
    private float _choicePriorities;

    public float Game => _game;
    public float SignsPlacement => _signsPlacement;
    public float ChoicePriorities => _choicePriorities;

    public PlayerStatsAverageTimes(float game, float signsPlacement, float choicePriorities)
    {
        _game = game;
        _signsPlacement = signsPlacement;
        _choicePriorities = choicePriorities;
    }
}
