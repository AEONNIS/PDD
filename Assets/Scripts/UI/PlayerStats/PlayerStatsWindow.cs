using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PlayerStatsWindow : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [TextArea(2, 4)] [SerializeField] private string _clearResultsConfirmMessage;
        [Header("UI Components:")]
        [SerializeField] private ConfirmationPanel _confirmationPanel;
        [SerializeField] private PlayerStatsResultsPanel _totalResultsPanel;
        [SerializeField] private PlayerStatsResultsPanel _last14DaysResultsPanel;
        [Header("Buttons:")]
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _clearPlayerStatsButton;

        private void Awake()
        {
            _newGameButton.onClick.RemoveAllListeners();
            _clearPlayerStatsButton.onClick.RemoveAllListeners();

            _newGameButton.onClick.AddListener(OnNewGameButtonClick);
            _clearPlayerStatsButton.onClick.AddListener(OnClearPlayerStatsButtonClick);
        }

        public void Present(PlayerStatsResults totalResults, PlayerStatsResults last14DaysResults)
        {
            _totalResultsPanel.Present(totalResults);
            _last14DaysResultsPanel.Present(last14DaysResults);
            gameObject.SetActive(true);
        }

        private void OnNewGameButtonClick()
        {
            gameObject.SetActive(false);
            _gameState.StartSignsPlacement();
        }

        private void OnClearPlayerStatsButtonClick()
        {
            gameObject.SetActive(false);
            _confirmationPanel.Init(_clearResultsConfirmMessage, _gameState.PlayerStatsClearAndUpdateStatsWindow, gameObject);
        }
    }
}
