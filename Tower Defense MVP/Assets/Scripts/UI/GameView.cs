using JGM.Gameplay;
using JGM.Gameplay.Base;
using JGM.Gameplay.Waves;
using UnityEngine;

namespace JGM.UI
{
    public class GameView : MonoBehaviour
    {
        [Header("Game Controller")]
        [SerializeField]
        private GameController gameController;

        [Header("Panels")]
        [SerializeField] private GameObject topPanel;
        [SerializeField] private GameObject bottomPanel;
        [SerializeField] private GameObject losePopup;
        [SerializeField] private GameObject winPopup;

        private void Awake()
        {
            var serviceLocator = ServiceLocator.Instance;
            var playerBase = serviceLocator.Get<PlayerBase>();
            var wavesController = serviceLocator.Get<WavesController>();

            gameController.OnGameStart += OnGameStart;
            playerBase.OnHealthDepleted += OnGameOver;
            wavesController.OnAllWavesComplete += OnGameWin;
        }

        private void OnGameStart()
        {
            topPanel.SetActive(true);
            bottomPanel.SetActive(true);
            losePopup.SetActive(false);
            winPopup.SetActive(false);
        }

        private void OnGameOver()
        {
            losePopup.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnGameWin()
        {
            winPopup.SetActive(true);
            Time.timeScale = 0;
        }
    }
}