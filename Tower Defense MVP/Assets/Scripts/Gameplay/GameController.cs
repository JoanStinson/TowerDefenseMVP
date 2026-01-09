using JGM.Gameplay.Waves;
using System;
using UnityEngine;

namespace JGM.Gameplay
{
    public class GameController : MonoBehaviour
    {
        public event Action OnGameStart;

        [SerializeField]
        private WavesController wavesController;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            wavesController.StartGame();
            OnGameStart?.Invoke();
        }
    }
}
