using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class StagesPanel : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private Crossroad _crossroad;
        [SerializeField] private ChoiceCarPriority _choiceCarPriority;
        [Header("TopPanel:")]
        [SerializeField] private Button _randomSignButton;
        [SerializeField] private Button _checkSignsButton;
        [SerializeField] private ResultCheckingSigns _resultCheckingSigns;
        [Header("BottomPanel:")]
        [SerializeField] private Button _generateCarsButton;
        [SerializeField] private Button _checkPrioritiesButton;
        [SerializeField] private Button _playerStatsButton;
        [SerializeField] private ResultsCheckingPriorities _resultsCheckingPriorities;

        private void Awake()
        {
            SetupButtonsActions();
            SetButtonsStates(false, false, false, false, false);

            _crossroad.AllSignsSet += () => SetButtonsStates(false, true, false, false, false);
            _crossroad.AllCarsUserPrioritiesSet += () => SetButtonsStates(false, false, false, true, false);
        }

        public void ResetPanel()
        {
            _resultCheckingSigns.ClearResult();
            _resultsCheckingPriorities.ClearResults();
            SetButtonsStates(false, false, false, false, false);
            gameObject.SetActive(true);
        }

        public void ChoicePrioritiesInit(List<Car> cars)
        {
            _resultsCheckingPriorities.Init(cars);
            _choiceCarPriority.Init(cars.Count);
            SetButtonsStates(false, false, false, false, false);
        }

        public bool CheckPriorities()
        {
            if (_resultsCheckingPriorities.CheckPriorities())
            {
                SetButtonsStates(true, false, false, false, true);
                return true;
            }
            else
            {
                SetButtonsStates(false, false, false, false, false);
                return false;
            }
        }

        private void SetupButtonsActions()
        {
            _randomSignButton.onClick.RemoveAllListeners();
            _checkSignsButton.onClick.RemoveAllListeners();
            _generateCarsButton.onClick.RemoveAllListeners();
            _checkPrioritiesButton.onClick.RemoveAllListeners();
            _playerStatsButton.onClick.RemoveAllListeners();

            _randomSignButton.onClick.AddListener(OnRandomSignClick);
            _checkSignsButton.onClick.AddListener(OnCheckSignsClick);
            _generateCarsButton.onClick.AddListener(OnGenerateCarsClick);
            _checkPrioritiesButton.onClick.AddListener(OnCheckPrioritiesClick);
            _playerStatsButton.onClick.AddListener(OnPlayerStatsButton);
        }

        private void SetButtonsStates(bool randomSignButton, bool checkSignsButton, bool generateCarsButton, bool checkPrioritiesButton, bool playerStatsButton)
        {
            _randomSignButton.interactable = randomSignButton;
            _checkSignsButton.interactable = checkSignsButton;
            _generateCarsButton.interactable = generateCarsButton;
            _checkPrioritiesButton.interactable = checkPrioritiesButton;
            _playerStatsButton.interactable = playerStatsButton;
        }

        private void OnRandomSignClick()
        {
            _gameState.StartSignsPlacement();
        }

        private void OnCheckSignsClick()
        {
            if (_gameState.CheckSignsPlacement())
            {
                _resultCheckingSigns.SetRightResult();
                SetButtonsStates(false, false, true, false, false);
            }
            else
            {
                _resultCheckingSigns.SetWrongResult();
                SetButtonsStates(false, false, false, false, false);
            }
        }

        private void OnGenerateCarsClick()
        {
            _gameState.StartChoicePriorities();
        }

        private void OnCheckPrioritiesClick()
        {
            _gameState.CheckPriorities();
        }

        private void OnPlayerStatsButton()
        {
            _gameState.ShowPlayerStatsWindow();
        }
    }
}
