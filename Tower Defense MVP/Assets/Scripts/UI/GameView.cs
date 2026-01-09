using JGM.Gameplay;
using JGM.Gameplay.Base;
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

        private void Awake()
        {
            gameController.OnGameStarted += OnGameStart;
            playerBase.OnHealthDecreased += OnHealthDecrease;
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
    }
}