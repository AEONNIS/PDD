using UnityEngine;

namespace Game.UI
{
    public class PlayerStatsResultsPanel : MonoBehaviour
    {
        [SerializeField] private PlayerStatsAmountsPanel _amountsPanel;
        [SerializeField] private PlayerStatsAverageTimesPanel _averageTimesPanel;

        public void Present(PlayerStatsResults results)
        {
            _amountsPanel.Present(results.Amounts);
            _averageTimesPanel.Present(results.AverageTimes);
        }
    }
}
