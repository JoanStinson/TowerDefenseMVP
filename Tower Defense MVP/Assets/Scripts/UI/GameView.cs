using JGM.Gameplay;
using JGM.Gameplay.Base;
using JGM.Gameplay.Waves;
using System;
using UnityEngine;

namespace JGM.UI
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private GameObject topPanel;
        [SerializeField] private GameObject bottomPanel;
        [SerializeField] private GameObject losePopup;
        [SerializeField] private GameObject winPopup;
        [SerializeField] private PlayerBase playerBase;
        [SerializeField] private WavesController wavesController;

        private void Awake()
        {
            gameController.OnGameStarted += OnGameStart;
            playerBase.OnHealthDecreased += OnHealthDecrease;
            wavesController.OnAllWavesComplete += OnAllWavesComplete;
        }

        private void OnGameStart()
        {
            topPanel.SetActive(true);
            bottomPanel.SetActive(true);
            losePopup.SetActive(false);
            winPopup.SetActive(false);
        }

        private void OnHealthDecrease(int health)
        {
            if (health <= 0)
            {
                losePopup.SetActive(true);
            }
        }

        private void OnAllWavesComplete()
        {
            winPopup.SetActive(true);
        }
    }
}