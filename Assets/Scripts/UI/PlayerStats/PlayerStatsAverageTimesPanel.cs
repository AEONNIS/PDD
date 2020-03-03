using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PlayerStatsAverageTimesPanel : MonoBehaviour
    {
        [SerializeField] private Text _game;
        [SerializeField] private Text _signsPlacement;
        [SerializeField] private Text _choicePriorities;

        public void Present(PlayerStatsAverageTimes averageTimes)
        {
            _game.text = $"{averageTimes.Game:N2}";
            _signsPlacement.text = $"{averageTimes.SignsPlacement:N2}";
            _choicePriorities.text = $"{averageTimes.ChoicePriorities:N2}";
        }
    }
}
