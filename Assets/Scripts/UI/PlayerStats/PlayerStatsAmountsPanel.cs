using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PlayerStatsAmountsPanel : MonoBehaviour
    {
        [SerializeField] private Text _totalGames;
        [SerializeField] private Text _wins;
        [SerializeField] private Text _losses;
        [SerializeField] private Text _timeIsOverLosses;
        [SerializeField] private Text _wrongAnswerLosses;

        public void Present(PlayerStatsAmounts amounts)
        {
            _totalGames.text = amounts.TotalGames.ToString();
            _wins.text = amounts.Wins.ToString();
            _losses.text = amounts.Losses.ToString();
            _timeIsOverLosses.text = amounts.TimeIsOverLosses.ToString();
            _wrongAnswerLosses.text = amounts.WrongAnswerLosses.ToString();
        }
    }
}
