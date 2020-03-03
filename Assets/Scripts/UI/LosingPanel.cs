using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class LosingPanel : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private Button _replayButton;
        [SerializeField] private Button _playerStatsButton;
        [Header("Messages:")]
        [SerializeField] private Text _lossMesage;
        [TextArea(2, 4)] [SerializeField] private string _timeIsOverMessage;
        [TextArea(2, 4)] [SerializeField] private string _wrongAnswerMessage;

        private void Awake()
        {
            _replayButton.onClick.RemoveAllListeners();
            _playerStatsButton.onClick.RemoveAllListeners();

            _replayButton.onClick.AddListener(OnReplayButtonClick);
            _playerStatsButton.onClick.AddListener(OnPlayerStatsButtonClcick);
        }

        public void Init(ReasonLosing reasonLosing)
        {
            _lossMesage.text = reasonLosing == ReasonLosing.TimeIsOver ? _timeIsOverMessage : _wrongAnswerMessage;
            gameObject.SetActive(true);
        }

        private void OnReplayButtonClick()
        {
            gameObject.SetActive(false);
            _gameState.StartSignsPlacement();
        }

        private void OnPlayerStatsButtonClcick()
        {
            gameObject.SetActive(false);
            _gameState.ShowPlayerStatsWindow();
        }
    }
}
